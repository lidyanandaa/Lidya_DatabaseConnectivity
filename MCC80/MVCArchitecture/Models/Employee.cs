using MVCArchitecture.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MVCArchitecture.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public DateTime hire_date { get; set; }
        public int salary { get; set; }
        public Decimal commission_pct { get; set; }
        public int manager_id { get; set; }
        public string job_id { get; set; }
        public int department_id { get; set; }

        //GET ALL EMPLOYEES
        public List<Employee> GetAll()
        {
            var connection = Connection.Get();

            var employees = new List<Employee>();

            using SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "SELECT * FROM EMPLOYEES";

            try
            {
                connection.Open();
                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.id = reader.GetInt32(0);
                        employee.first_name = reader.GetString(1);
                        employee.last_name = reader.GetString(2);
                        employee.email = reader.GetString(3);
                        employee.phone_number = reader.GetString(4);
                        employee.hire_date = reader.GetDateTime(5);
                        employee.salary = reader.GetInt32(6);
                        employee.commission_pct = reader.GetDecimal(7);
                        employee.manager_id = reader.GetInt32(8);
                        employee.job_id = reader.GetString(9);
                        employee.department_id = reader.GetInt32(10);

                        employees.Add(employee);
                    }
                }
                else
                {
                    reader.Close();
                    connection.Close();
                }

                return employees;
            }
            catch
            {
                return new List<Employee>();
            }
        }

        // INSERT EMPLOYEES
        public int Insert(Employee employee)
        {
            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "INSERT INTO employees(id, first_name, last_name, email, phone_number, hire_date, salary, " +
           "commission_pct, manager_id, job_id, department_id)" +
           "VALUES (@id, @first_name, @last_name, @email, @phone_number, @hire_date, @salary, @commission_pct, @manager_id, " +
           "@job_id, @department_id)";


            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = employee.id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pFirstName = new SqlParameter();
                pFirstName.ParameterName = "@first_name";
                pFirstName.SqlDbType = System.Data.SqlDbType.VarChar;
                pFirstName.Value = employee.first_name;
                sqlCommand.Parameters.Add(pFirstName);

                SqlParameter pLastName = new SqlParameter();
                pLastName.ParameterName = "@last_name";
                pLastName.SqlDbType = System.Data.SqlDbType.VarChar;
                pLastName.Value = employee.last_name;
                sqlCommand.Parameters.Add(pLastName);

                SqlParameter pEmail = new SqlParameter();
                pEmail.ParameterName = "@email";
                pEmail.SqlDbType = System.Data.SqlDbType.VarChar;
                pEmail.Value = employee.email;
                sqlCommand.Parameters.Add(pEmail);

                SqlParameter pPhone = new SqlParameter();
                pPhone.ParameterName = "@phone_number";
                pPhone.SqlDbType = System.Data.SqlDbType.VarChar;
                pPhone.Value = employee.phone_number;
                sqlCommand.Parameters.Add(pPhone);

                SqlParameter pHireDate = new SqlParameter();
                pHireDate.ParameterName = "@hire_date";
                pHireDate.SqlDbType = System.Data.SqlDbType.VarChar;
                pHireDate.Value = employee.hire_date;
                sqlCommand.Parameters.Add(pHireDate);

                SqlParameter pSalary = new SqlParameter();
                pSalary.ParameterName = "@salary";
                pSalary.SqlDbType = System.Data.SqlDbType.Int;
                pSalary.Value = employee.salary;
                sqlCommand.Parameters.Add(pSalary);

                SqlParameter pCom = new SqlParameter();
                pCom.ParameterName = "@commission_pct";
                pCom.SqlDbType = System.Data.SqlDbType.Decimal;
                pCom.Value = employee.commission_pct;
                sqlCommand.Parameters.Add(pCom);

                SqlParameter pIdMan = new SqlParameter();
                pIdMan.ParameterName = "@manager_id";
                pIdMan.SqlDbType = System.Data.SqlDbType.Int;
                pIdMan.Value = employee.manager_id;
                sqlCommand.Parameters.Add(pIdMan);

                SqlParameter pJob = new SqlParameter();
                pJob.ParameterName = "@job_id";
                pJob.SqlDbType = System.Data.SqlDbType.VarChar;
                pJob.Value = employee.job_id;
                sqlCommand.Parameters.Add(pJob);

                SqlParameter pIdDep = new SqlParameter();
                pIdDep.ParameterName = "@department_id";
                pIdDep.SqlDbType = System.Data.SqlDbType.Int;
                pIdDep.Value = employee.department_id;
                sqlCommand.Parameters.Add(pIdDep);

                int result = sqlCommand.ExecuteNonQuery();

                transaction.Commit();
                connection.Close();

                return result; // 0 gagal, >= 1 berhasil
            }
            catch
            {
                transaction.Rollback();
                return -1; // Kesalahan terjadi pada database
            }
        }

        //UPDATE EMPLOYEES
        public int Update(Employee employee)
        {
            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "update employees set first_name = @first_name, last_name = @last_name, email = @email, phone_number = @phone_number, hire_date = @hire_date, salary = @salary, commission_pct = @commission_pct, manager_id = @manager_id, job_id = @job_id, department_id = @department_id WHERE id = @id";

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = employee.id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pFirstName = new SqlParameter();
                pFirstName.ParameterName = "@first_name";
                pFirstName.SqlDbType = System.Data.SqlDbType.VarChar;
                pFirstName.Value = employee.first_name;
                sqlCommand.Parameters.Add(pFirstName);

                SqlParameter pLastName = new SqlParameter();
                pLastName.ParameterName = "@last_name";
                pLastName.SqlDbType = System.Data.SqlDbType.VarChar;
                pLastName.Value = employee.last_name;
                sqlCommand.Parameters.Add(pLastName);

                SqlParameter pEmail = new SqlParameter();
                pEmail.ParameterName = "@email";
                pEmail.SqlDbType = System.Data.SqlDbType.VarChar;
                pEmail.Value = employee.email;
                sqlCommand.Parameters.Add(pEmail);

                SqlParameter pPhone = new SqlParameter();
                pPhone.ParameterName = "@phone_number";
                pPhone.SqlDbType = System.Data.SqlDbType.VarChar;
                pPhone.Value = employee.phone_number;
                sqlCommand.Parameters.Add(pPhone);

                SqlParameter pHireDate = new SqlParameter();
                pHireDate.ParameterName = "@hire_date";
                pHireDate.SqlDbType = System.Data.SqlDbType.VarChar;
                pHireDate.Value = employee.hire_date;
                sqlCommand.Parameters.Add(pHireDate);

                SqlParameter pSalary = new SqlParameter();
                pSalary.ParameterName = "@salary";
                pSalary.SqlDbType = System.Data.SqlDbType.Int;
                pSalary.Value = employee.salary;
                sqlCommand.Parameters.Add(pSalary);

                SqlParameter pCom = new SqlParameter();
                pCom.ParameterName = "@commission_pct";
                pCom.SqlDbType = System.Data.SqlDbType.Decimal;
                pCom.Value = employee.commission_pct;
                sqlCommand.Parameters.Add(pCom);

                SqlParameter pIdMan = new SqlParameter();
                pIdMan.ParameterName = "@manager_id";
                pIdMan.SqlDbType = System.Data.SqlDbType.Int;
                pIdMan.Value = employee.manager_id;
                sqlCommand.Parameters.Add(pIdMan);

                SqlParameter pJob = new SqlParameter();
                pJob.ParameterName = "@job_id";
                pJob.SqlDbType = System.Data.SqlDbType.VarChar;
                pJob.Value = employee.job_id;
                sqlCommand.Parameters.Add(pJob);

                SqlParameter pIdDep = new SqlParameter();
                pIdDep.ParameterName = "@department_id";
                pIdDep.SqlDbType = System.Data.SqlDbType.Int;
                pIdDep.Value = employee.department_id;
                sqlCommand.Parameters.Add(pIdDep);

                int result = sqlCommand.ExecuteNonQuery();

                transaction.Commit();
                connection.Close();

                return result;

            }
            catch
            {
                transaction.Rollback();
                return -1;
            }
        }


        //DELETE EMPLOYEES
        public int Delete(int id)
        {
            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "DELETE FROM EMPLOYEES WHERE ID = @id";

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pEmployeeId = new SqlParameter();
                pEmployeeId.ParameterName = "@id";
                pEmployeeId.SqlDbType = System.Data.SqlDbType.Int;
                pEmployeeId.Value = id;
                sqlCommand.Parameters.Add(pEmployeeId);

                int result = sqlCommand.ExecuteNonQuery();

                transaction.Commit();
                connection.Close();

                return result;
            }
            catch
            {
                transaction.Rollback();
                return -1;
            }
        }

        //GET BY ID EMPLOYEES
        public Employee GetById(int id)
        {
            var employee = new Employee();

            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "SELECT * FROM EMPLOYEES WHERE ID = @id";

            sqlCommand.Parameters.AddWithValue("@employee_id", id);

            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                        reader.Read();
                    employee.id = reader.GetInt32(0);
                    employee.first_name = reader.GetString(1);
                    employee.last_name = reader.GetString(2);
                    employee.email = reader.GetString(3);
                    employee.phone_number = reader.GetString(4);
                    employee.hire_date = reader.GetDateTime(5);
                    employee.salary = reader.GetInt32(6);
                    employee.commission_pct = reader.GetDecimal(7);
                    employee.manager_id = reader.GetInt32(8);
                    employee.job_id = reader.GetString(9);
                    employee.department_id = reader.GetInt32(10);
                }

                reader.Close();
                connection.Close();

                return employee;
            }
            catch
            {
                return new Employee();
            }
        }
    }
}
