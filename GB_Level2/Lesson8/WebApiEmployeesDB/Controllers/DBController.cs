using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiEmployeesDB.Models;
using EmployeeCard.DataBaseClasses;

namespace WebApiEmployeesDB.Controllers
{
    public class DBController : ApiController
    {
        private Manipulate manipulate = new Manipulate();
        [Route("GetAllDepartments")]
        public List<Department> GetAllDepartments()
        {
            return manipulate.GetAllDepartments();
        }
        [Route("GetDepartment/{deptId}")]
        public Department GetDepartment(int deptId)
        {
            return manipulate.GetDepartment(deptId);
        }
        [Route("GetDeptEmployees/{id}")]
        public List<Employee> GetEmployees(int id)
        {
            return manipulate.GetEmployees(id);
        }
        [Route("AddDepartment")]
        public HttpResponseMessage AddDepartment([FromBody]Department department)
        {
            if (manipulate.WorkDepartment(department,DbAction.Insert))
                return Request.CreateResponse(HttpStatusCode.Created);
            else return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
        [Route("ModifyDepartment")]
        public HttpResponseMessage ModifyDepartment([FromBody]Department department)
        {
            if (manipulate.WorkDepartment(department, DbAction.Update))
                return Request.CreateResponse(HttpStatusCode.Created);
            else return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
        [Route("AddEmployee")]
        public HttpResponseMessage AddEmployee([FromBody]Employee employee)
        {
            if (manipulate.WorkEmployee(employee,DbAction.Insert))
                return Request.CreateResponse(HttpStatusCode.Created);
            else return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
        [Route("ModifyEmployee")]
        public HttpResponseMessage ModifyEmployee([FromBody]Employee employee)
        {
            if (manipulate.WorkEmployee(employee,DbAction.Update))
                return Request.CreateResponse(HttpStatusCode.Created);
            else return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
