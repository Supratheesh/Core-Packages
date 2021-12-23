using Microsoft.Extensions.Logging;

namespace MyProduct.API.Extensions
{
    public abstract class ControllerBase: Microsoft.AspNetCore.Mvc.ControllerBase
    {
        #region Properties

        /// <summary>
        /// Logger for contoller level logging.
        /// </summary>
        protected ILogger Logger { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Create Instance for contoller base class.
        /// </summary>
        /// <param name="logger">Logger Instance for logging</param>
        protected ControllerBase(ILogger logger)
        {
            Logger = logger;
        }

        #endregion
    }
}
