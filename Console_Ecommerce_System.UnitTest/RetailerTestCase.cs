using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Console_Ecommerce_System.BusinessLayer;
using Console_Ecommerce_System.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Console_Ecommerce_System.UnitTests
{
    [TestClass]
    public class AddCustomerBLTest
    {
        /// <summary>
        /// Add Customer to the Collection if it is valid.
        /// </summary>
        [TestMethod]
        public async Task AddValidCustomer()
        {
            //Arrange
            CustomerBL CustomerBL = new CustomerBL();
            Customer Customer = new Customer() { CustomerName = "Scott", CustomerMobile = "9876543210", Password = "Scott123#", Email = "scott1@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;
            Guid newGuid;

            //Act
            try
            {
                (isAdded,newGuid) = await CustomerBL.AddCustomerBL(Customer);
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
        /// Customer Name can't be null
        /// </summary>
        [TestMethod]
        public async Task CustomerNameCanNotBeNull()
        {
            //Arrange
            CustomerBL CustomerBL = new CustomerBL();
            Customer Customer = new Customer() { CustomerName = null, CustomerMobile = "9988776655", Password = "Smith123#", Email = "smith@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;
            Guid newGuid;

            //Act
            try
            {
                (isAdded,newGuid) = await CustomerBL.AddCustomerBL(Customer);
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
        /// Customer Mobile can't be null
        /// </summary>
        [TestMethod]
        public async Task CustomerMobileCanNotBeNull()
        {
            //Arrange
            CustomerBL CustomerBL = new CustomerBL();
            Customer Customer = new Customer() { CustomerName = "Smith", CustomerMobile = null, Password = "Smith123#", Email = "smith@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;
            Guid newGuid;

            //Act
            try
            {
                (isAdded,newGuid) = await CustomerBL.AddCustomerBL(Customer);
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
        /// Customer Password can't be null
        /// </summary>
        [TestMethod]
        public async Task CustomerPasswordCanNotBeNull()
        {
            //Arrange
            CustomerBL CustomerBL = new CustomerBL();
            Customer Customer = new Customer() { CustomerName = "Allen", CustomerMobile = "9877766554", Password = null, Email = "allen@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;
            Guid newGuid;

            //Act
            try
            {
                (isAdded,newGuid) = await CustomerBL.AddCustomerBL(Customer);
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
        /// Customer Email can't be null
        /// </summary>
        [TestMethod]
        public async Task CustomerEmailCanNotBeNull()
        {
            //Arrange
            CustomerBL CustomerBL = new CustomerBL();
            Customer Customer = new Customer() { CustomerName = "John", CustomerMobile = "9876543210", Password = "John123#", Email = null };
            bool isAdded = false;
            string errorMessage = null;
            Guid newGuid;

            //Act
            try
            {
                (isAdded,newGuid) = await CustomerBL.AddCustomerBL(Customer);
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
        /// CustomerName should contain at least two characters
        /// </summary>
        [TestMethod]
        public async Task CustomerNameShouldContainAtLeastTwoCharacters()
        {
            //Arrange
            CustomerBL CustomerBL = new CustomerBL();
            Customer Customer = new Customer() { CustomerName = "J", CustomerMobile = "9877897890", Password = "John123#", Email = "john@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;
            Guid newGuid;

            //Act
            try
            {
                (isAdded,newGuid) = await CustomerBL.AddCustomerBL(Customer);
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
        /// CustomerMobile should be a valid mobile number
        /// </summary>
        [TestMethod]
        public async Task CustomerMobileRegExp()
        {
            //Arrange
            CustomerBL CustomerBL = new CustomerBL();
            Customer Customer = new Customer() { CustomerName = "John", CustomerMobile = "9877", Password = "John123#", Email = "john@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;
            Guid newGuid;

            //Act
            try
            {
                (isAdded,newGuid) = await CustomerBL.AddCustomerBL(Customer);
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
        /// Password should be a valid password as per regular expression
        /// </summary>
        [TestMethod]
        public async Task CustomerPasswordRegExp()
        {
            //Arrange
            CustomerBL CustomerBL = new CustomerBL();
            Customer Customer = new Customer() { CustomerName = "John", CustomerMobile = "9877897890", Password = "John", Email = "john@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;
            Guid newGuid;

            //Act
            try
            {
                (isAdded,newGuid) = await CustomerBL.AddCustomerBL(Customer);
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
        /// Email should be a valid email as per regular expression
        /// </summary>
        [TestMethod]
        public async Task CustomerEmailRegExp()
        {
            //Arrange
            CustomerBL CustomerBL = new CustomerBL();
            Customer Customer = new Customer() { CustomerName = "John", CustomerMobile = "9877897890", Password = "John123#", Email = "john" };
            bool isAdded = false;
            string errorMessage = null;
            Guid newGuid;

            //Act
            try
            {
                (isAdded,newGuid) = await CustomerBL.AddCustomerBL(Customer);
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


