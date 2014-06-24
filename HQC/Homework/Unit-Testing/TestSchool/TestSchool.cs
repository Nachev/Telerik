using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School;

namespace TestSchool
{
    [TestClass]
    public class TestSchool
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSchoolCreationWithEmptyNameShouldThrowException()
        {
            var testSchool = new School.School("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSchoolCreationWithNullNameShouldThrowException()
        {
            var testSchool = new School.School(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestStudentsCreationWithExistingOneShouldThrowException()
        {
            var testSchool = new School.School("testSchoolName");
            testSchool.GenerateStudent("Test Student Name", 10001);
            testSchool.GenerateStudent("Test Student Name Two", 10001);
        }

        [TestMethod]
        public void TestGetNamePropertyShouldWorkProperly()
        {
            var testCourse = new School.School("testSchoolName");
            Assert.AreEqual(
                testCourse.Name,
                "testSchoolName",
                "Test school name is not equal to the one got from the property."
                );
        }

        [TestMethod]
        public void TestGetListOfCoursesPropertyShouldReturnDeepCopyOfTheList()
        {
            var testSchool = new School.School("Test School");
            testSchool.GenerateCourse("Test Course Name");
            Assert.AreNotSame(testSchool.ListOfCourses[0], testSchool.ListOfCourses[0],
                "Courses list property returns same course as first member, but should be copy.");
        }

        [TestMethod]
        public void TestGenerateStudentMethodShouldWorkProperly()
        {
            var testSchool = new School.School("Test School");
            testSchool.GenerateStudent("Test Student Name", 10001);
            Assert.AreEqual(
                testSchool.ListOfStudents[0].Name,
                "Test Student Name",
                "Generated student name is not equal to the one entered."
                );
        }
    }
}
