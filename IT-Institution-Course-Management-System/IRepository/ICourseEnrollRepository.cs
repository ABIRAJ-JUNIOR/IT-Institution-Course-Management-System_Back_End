﻿using IT_Institution_Course_Management_System.Models.RequestModels;
using IT_Institution_Course_Management_System.Models.ResponseModels;

namespace IT_Institution_Course_Management_System.IRepository
{
    public interface ICourseEnrollRepository
    {
        ICollection<CourseEnrollResponseDTO> GetAllEnrollData();
        CourseEnrollResponseDTO AddEnrollDetails(AddCourseEnrollDTO AddEnrollDto);
        void AddPaymentId(string CourseEnrollId, string InstallmentId, string FullPaymentId);
        void UpdateStatus(string CourseEnrollId, string Status);
    }
}
