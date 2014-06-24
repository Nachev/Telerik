using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School;

namespace TestSchool
{
    [TestClass]
    public class TestStudent
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudentCreationWithEmptyNameShouldThrowException()
        {
            var testStudent = new Student(10345, "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestStudentCreationWithNullNameShouldThrowException()
        {
            string testName = null;
            var testStudent = new Student(10345, testName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestStudentCreationWithInvalidIDNumberShouldThrowException()
        {
            var testStudent = new Student(-345, "Test name");
        }

        [TestMethod]
        public void TestStudentAttendCourseMethodShouldWorkProperly()
        {
            var testCourse = new Course("testCourseName");
            var testStudent = new Student(10001, "Test Student Name");
            testStudent.AttendCourse(testCourse);
            Assert.AreEqual(
                testStudent.Name,
                testCourse.Students[0].Name,
                "First inserted student's name is not equal to the first name in the list"
                );
        }

        [TestMethod]
        public void TestLeaveCourseMethodShouldWorkProperly()
        {
            var testCourse = new Course("testCourseName");
            var testStudent = new Student(10001, "Test Student Name");
            testStudent.AttendCourse(testCourse);
            testStudent.LeaveCourse(testCourse);
            Assert.IsTrue(
                testCourse.Students.Count == 0,
                "Students list count is not equal to zero"
                );
        }
    }
}
