﻿using Console_Ecommerce_System.BusinessLayer;
using Console_Ecommerce_System.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Console_Ecommerce_System.UnitTests
{
    [TestClass]
    public class AddOrderBLTest
    {
        /// <summary>
        /// AddOrder to the Collection if it is valid.
        /// </summary>
        [TestMethod]
        public async Task AddValidOrder()
        {
            //Arrange
            OrderBL orderBL = new OrderBL();
            Order order = new Order() { OrderAmount = 10, TotalQuantity = 10, };
            bool isAdded = false;
            Guid newGuid;
            string errorMessage = null;

            //Act
            try
            {
                Customer Customer = new Customer() { CustomerID = Guid.NewGuid(), CustomerName = "Abhishek", CustomerMobile = "9039607074", Password = "Abhishek@2", Email = "abhi.rajawat11@gmail.com" };

                CustomerBL CustomerBL = new CustomerBL();
                bool isAdded1 = false;
                Guid newGuid1;
                (isAdded1, newGuid1) = await CustomerBL.AddCustomerBL(Customer);
                Customer.CustomerID = newGuid1;
                order.CustomerID = newGuid1;
                (isAdded, newGuid) = await orderBL.AddOrderBL(order);
                
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// Customer ID should be unique and present in database
        /// </summary>
        [TestMethod]
        public async Task CustomerIDNotMatch()
        {
            //Arrange
            OrderBL orderBL = new OrderBL();
            Order order = new Order() { CustomerID = Guid.NewGuid(), OrderAmount = 10, TotalQuantity = 10 };
            bool isAdded = false;
            Guid newGuid;
            string errorMessage = null;

            //Act
            try
            {
                (isAdded, newGuid) = await orderBL.AddOrderBL(order);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }


        /// <summary>
        /// Total Amount of Order can't be negative
        /// </summary>
        [TestMethod]
        public async Task TotalAmountCannotBeNegative()
        {
            //Arrange
            OrderBL orderBL = new OrderBL();
            Order order = new Order() { CustomerID = Guid.NewGuid(), OrderAmount = -10, TotalQuantity = 10 };
            bool isAdded = false;
            Guid newGuid;
            string errorMessage = null;

            //Act
            try
            {
                (isAdded, newGuid) = await orderBL.AddOrderBL(order);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// Total Quantity of Order can't be negative
        /// </summary>
        [TestMethod]
        public async Task TotalQuantityCannotBeNegative()
        {
            //Arrange
            OrderBL orderBL = new OrderBL();
            Order order = new Order() { CustomerID = Guid.NewGuid(), OrderAmount = 10, TotalQuantity = -10 };
            bool isAdded = false;
            Guid newGuid;
            string errorMessage = null;

            //Act
            try
            {
                (isAdded, newGuid) = await orderBL.AddOrderBL(order);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }


    }
}