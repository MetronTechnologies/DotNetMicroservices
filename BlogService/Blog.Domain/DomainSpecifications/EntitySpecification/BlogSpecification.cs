using System.Linq.Expressions;
using Blog.Domain.Entities;

namespace Blog.Domain.DomainSpecifications.EntitySpecification;

public class BlogQueryBuilder {
    public Expression<Func<BlogModel, bool>> GetBlogs(BlogModel model) {
        Expression<Func<BlogModel, bool>> expression = PredicateBuilder.True<BlogModel>();

        if (!string.IsNullOrEmpty(model.Name)) {
            expression = expression.And(e => e.Name.Contains(model.Name));
        }

        if (!string.IsNullOrEmpty(model.Description)) {
            expression = expression.And(e => e.Description == model.Description);
        }

        if (!string.IsNullOrEmpty(model.Author)) {
            expression = expression.And(e => e.Author == model.Author);
        }

        return expression;
    }

    // public IQueryable<Employee> GetEmployees(EmployeeQuery query) {
    //     var predicate = PredicateBuilder.False<Employee>();
    //     if (!string.IsNullOrEmpty(query.Name)) {
    //         var namePredicate = PredicateBuilder.New<Employee>(e => e.Name.Contains(query.Name));
    //         predicate = predicate.Or(namePredicate);
    //     }
    //     if (!string.IsNullOrEmpty(query.Department)) {
    //         var departmentPredicate = PredicateBuilder.New<Employee>(e => e.Department.Contains(query.Department));
    //         predicate = predicate.Or(departmentPredicate);
    //     }
    //     return _context.Employees.Where(predicate);
    // }
    
    
    
    /*
     var employeeQuery1 = new EmployeeQuery
       {
       Name = "John"
       };
       var employees1 = queryService.GetEmployees(employeeQuery1).ToList();
       
       // Example 2: Search by department
       var employeeQuery2 = new EmployeeQuery
       {
       Department = "HR"
       };
       var employees2 = queryService.GetEmployees(employeeQuery2).ToList();
       
       // Example 3: Search by both name and department
       var employeeQuery3 = new EmployeeQuery
       {
       Name = "Jane",
       Department = "Finance"
       };
       var employees3 = queryService.GetEmployees(employeeQuery3).ToList();
     */
    
    
}