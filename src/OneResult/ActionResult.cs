using System.Collections.Generic;

namespace OneResult
{
    public class ActionResult
    {
        private List<ActionError> _errors = new List<ActionError>();
        public bool Successed { get;  set; }
        public IEnumerable<ActionError> Errors => _errors;

        public static ActionResult Success()
        {
            return new ActionResult() { Successed = true };
        }

        public static ActionResult Failed()
        {
            return new ActionResult() { Successed = false };
        }

        public static ActionResult Failed(params ActionError[] errors)
        {
            var result = new ActionResult() { Successed = false };
            result._errors.AddRange(errors);
            return result;
        }
    }
}
