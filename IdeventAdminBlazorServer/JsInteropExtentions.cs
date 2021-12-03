using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace IdeventAdminBlazorServer
{
    public static class JsInteropExtentions
    {
        public static ValueTask FocusAsync(this IJSRuntime jsRuntime, ElementReference elementReference)
        {
            return jsRuntime.InvokeVoidAsync("BlazorFocusElement", elementReference);
        }
    }
}
