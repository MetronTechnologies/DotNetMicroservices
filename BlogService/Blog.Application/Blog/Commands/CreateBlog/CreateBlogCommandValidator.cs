using FluentValidation;

namespace Blog.Application.Blog.Commands.CreateBlog; 

public class CreateBlogCommandValidator: AbstractValidator<CreateBlogCommand> {
    
    public CreateBlogCommandValidator() {
        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Name is required")
            .MinimumLength(3).WithMessage("Name length has to be at least 3 characters")
            .MaximumLength(200).WithMessage("Name length can not be longer than 200");

        RuleFor(v => v.Description)
            .NotEmpty().WithMessage("Description is required");

        RuleFor(v => v.Author)
            .NotEmpty().WithMessage("Author is required")
            .MaximumLength(20).WithMessage("Author is required");
    }
    
}