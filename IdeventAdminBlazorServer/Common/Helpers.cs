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
    }
}
