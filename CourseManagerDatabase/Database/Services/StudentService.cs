﻿using CourseManagerDatabase.Entity;

namespace CourseManagerDatabase.Database.Services
{
    public class StudentService(SchoolDbContext db)
    {
        private readonly SchoolDbContext _db = db;

        public void AddStudentRecord(StudentRecord studentRecord) => _db.Students.Add(studentRecord);

        public List<StudentRecord> GetStudents() => [.. _db.Students];

        public bool UpdateStudent(StudentRecord studentRecord)
        {
            var existingStudent = _db.Students.FirstOrDefault(s => s.Id == studentRecord.Id);
            if (existingStudent != null)
            {
                existingStudent.Name = studentRecord.Name;
                existingStudent.Surname = studentRecord.Surname;
                existingStudent.Patronymic = studentRecord.Patronymic;
                existingStudent.Birthday = studentRecord.Birthday;
                existingStudent.Email = studentRecord.Email;
                existingStudent.Rating = studentRecord.Rating;
                existingStudent.GroupId = studentRecord.GroupId;
                existingStudent.Group = studentRecord.Group;
                _db.SaveChanges();
                return true;
            }
            return false;
        }


        public bool DeleteStudent(StudentRecord studentRecord)
        {
            if (_db.Students.Any(g => g.Id == studentRecord.Id))
            {
                _db.Students.Remove(_db.Students.First(g => g.Id == studentRecord.Id));
                return true;
            }
            return false;
        }
    }
}
