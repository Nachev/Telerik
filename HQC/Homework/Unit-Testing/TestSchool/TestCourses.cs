namespace TestSchool
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;

    [TestClass]
    public class TestCourses
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseCreationWithEmptyNameShouldThrowException()
        {
            var testCourse = new Course("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCourseCreationWithNullNameShouldThrowException()
        {
            var testCourse = new Course(null);
        }

        [TestMethod]
        public void TestGetNamePropertyShouldWorkProperly()
        {
            var testCourse = new Course("testCourseName");
            Assert.AreEqual(
                testCourse.Name, 
                "testCourseName",
                "Test course name is not equal to the one got from the property."
                );
        }

        [TestMethod]
        public void TestInsertStudentsMethodShouldWorkProperly()
        {
            var testCourse = new Course("testCourseName");
            var testStudent = new Student(10001, "Test Student Name");
            testCourse.InsertStudent(testStudent);
            Assert.AreEqual(
                testStudent.Name, 
                testCourse.Students[0].Name, 
                "First inserted student's name is not equal to the first name in the list"
                );
        }

        [TestMethod]
        public void TestRemoveStudentsMethodShouldWorkProperly()
        {
            var testCourse = new Course("testCourseName");
            var testStudent = new Student(10001, "Test Student Name");
            testCourse.InsertStudent(testStudent);
            testCourse.RemoveStudent(testStudent);
            Assert.IsTrue(
                testCourse.Students.Count == 0,
                "Students list count is not equal to zero"
                );
        }

        [TestMethod]
        public void TestGetStudentsPropertyShouldReturnDifferentObjectEachCall()
        {
            var testCourse = new Course("testCourseName");
            var testStudent = new Student(10001, "Test Student Name");
            testCourse.InsertStudent(testStudent);
            Assert.AreNotSame(testCourse.Students, testCourse.Students,
                "Student list property returns same object, but should be copy.");
        }

        [TestMethod]
        public void TestGetStudentsPropertyShouldReturnDeepCopyOfTheList()
        {
            var testCourse = new Course("testCourseName");
            var testStudent = new Student(10001, "Test Student Name");
            testCourse.InsertStudent(testStudent);
            Assert.AreNotSame(testCourse.Students[0], testCourse.Students[0],
                "Student list property returns same student as first member, but should be copy.");
        }
    }
}
