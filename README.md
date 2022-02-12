# OneResult

**OneResult** is a simple library that provides an output model which can be used as an output result for methods.
By using **OneResult**, all methods in each layer, return same Model.

# Install OneResult

    Install-Package OneResult -Version 1.0.0

# how to use OneResult.

**OneResult** contains one main model which name is `ActionResult`. below are some examples to help you know how to use it.

If everything goes fine, you just need to return Success as below:

    return ActionResult.Success();
   
If something goes wrong, you can return Failed ActionResult as below;

    return ActionResult.Failed();
You also can add error details while returning Failed:

    return ActionResult.Failed(new ActionError { Code = "404", Description = "bookmark does not exists" });

## Return success and Error by OneResult

First, add OneResult namespace 

    using OneResult;
  Below is a real usage of ActionResult :  

      public ActionResult Delete(int id)
        {
            var bookmark =  _dbContext.Bookmarks.FirstOrDefault(b => b.Id == id);
            if (bookmark == null)
                return ActionResult.Failed(new ActionError { Code = "404", Description = "bookmark does not exists" });
            _dbContext.Bookmarks.Remove(bookmark);
             _dbContext.SaveChanges();
            return ActionResult.Success();
        }

    

## ActionResult and Return Data

If your methods need to return data (one or more records), you can define ActionResult like below:

    public ActionResult<BookmarkEntity> Get(int id)
        {
            var bookmark = _dbContext.Bookmarks.FirstOrDefault(b => b.Id == id);
            return ActionResult<BookmarkEntity>.Success(bookmark);
        }

also possible to return `List<T>` like this method:

     public ActionResult<IEnumerable<BookmarkEntity>> GetAll()
        {
            var bookmarks = _dbContext.Bookmarks.ToList();
            return ActionResult<IEnumerable<BookmarkEntity>>.Success(bookmarks);
        }


# Use ActionResult with MediatR

If you are using `MediatR`, it's possible to use OneResult in order to have Just one Output model.

## ActionResult and Commands

     public class CreateBookmarkCommand : IRequest<ActionResult<BookmarkDto>>
    {
        public string Path { get; init; }
        public Browser Browser { get; init; }
        public int UserId { get; init; }

    }

     public class CreateBookmarkCommandHandler : IRequestHandler<CreateBookmarkCommand, ActionResult<BookmarkDto>>
    {

        public async Task<ActionResult<BookmarkDto>> Handle(CreateBookmarkCommand request, CancellationToken cancellationToken)
        {
           // rest of implementation
            return ActionResult<BookmarkDto>.Success(dto);
        }
    }
