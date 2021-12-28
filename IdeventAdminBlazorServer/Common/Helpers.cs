using Microsoft.AspNetCore.Components;

namespace IdeventAdminBlazorServer.Common
{
    public class Helpers
    {
        /// <summary>
        /// Makes a RenderFragment with a div.alert that is either success or danger.
        /// </summary>
        /// <param name="message">The message you want to display in the alert div.</param>
        /// <param name="isError">If true the div has the class alert-danger. If false the class is alert-success</param>
        /// <returns></returns>
        public static RenderFragment MakeDisplayMessage(string message, bool isError)
        {
            RenderFragment renderFragment;
            if (isError)
            {
                 renderFragment = renderTreeBuilder =>
                {
                    string markup = $"<div class='alert alert-danger'>{message}</div>";
                    renderTreeBuilder.AddMarkupContent(markup.Length, markup);
                };
                return renderFragment;
            }

            renderFragment = renderTreeBuilder =>
            {
                string markup = $"<div class='alert alert-success'>{message}</div>";
                renderTreeBuilder.AddMarkupContent(markup.Length, markup);
            };
            return renderFragment;
        }
        /// <summary>
        /// Shortcut for navigation in e.g. the NavigateButton component's PageToNavigateTo Property.
        /// </summary>
        /// <param name="navigationPrefix">The @page you want to navigate to (add a / at the end if you specify modelId)</param>
        /// <param name="modelId">(optional) if you're going to a specific models page (edit or details) you can set its id here.</param>
        /// <returns></returns>
        public static string NavigationArgument(string navigationPrefix, int modelId = 0)
        {
            if(modelId == 0)
            {
                return $"{navigationPrefix}";
            }
            return $"{navigationPrefix}{modelId}";
        }
        /// <summary>
        /// Shortcut for navigation in e.g. the NavigateButton component's PageToNavigateTo Property.
        /// </summary>
        /// <param name="navigationPrefix">The @page you want to navigate to (add a / at the end if you specify modelId)</param>
        /// <param name="modelId">(optional) if you're going to a specific models page (edit or details) you can set its id here.</param>
        /// <returns></returns>
        public static string NavigationArgument(string navigationPrefix, string modelId)
        {
            if (string.IsNullOrWhiteSpace(modelId))
            {
                return $"{navigationPrefix}";
            }
            return $"{navigationPrefix}{modelId}";
        }
    }
}
