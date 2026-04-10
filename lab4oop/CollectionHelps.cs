using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab_4_OOP
{
    class EnterpriseByEmployeesComparer : IComparer<Enterprise>
    {
        public int Compare(Enterprise x, Enterprise y)
        {
            int employeesX = 0;
            int employeesY = 0;

            if (x is InsuranceCompany)
                employeesX = ((InsuranceCompany)x).Employees;
            else if (x is OilGasCompany)
                employeesX = ((OilGasCompany)x).Employees;
            else if (x is Factory)
                employeesX = ((Factory)x).Employees;

            if (y is InsuranceCompany)
                employeesY = ((InsuranceCompany)y).Employees;
            else if (y is OilGasCompany)
                employeesY = ((OilGasCompany)y).Employees;
            else if (y is Factory)
                employeesY = ((Factory)y).Employees;

            return employeesX.CompareTo(employeesY);
        }
    }

    class EnterpriseByRatingComparer : IComparer<Enterprise>
    {
        public int Compare(Enterprise x, Enterprise y)
        {
            return x.Rating.CompareTo(y.Rating);
        }
    }

    class EnterpriseCollection : IEnumerable<Enterprise>
    {
        private List<Enterprise> enterprises = new List<Enterprise>();

        public void Add(Enterprise enterprise)
        {
            enterprises.Add(enterprise);
        }

        public IEnumerator<Enterprise> GetEnumerator()
        {
            return enterprises.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}