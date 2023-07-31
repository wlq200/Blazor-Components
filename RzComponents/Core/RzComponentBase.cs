using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.ObjectPool;
using System.Text;

namespace RzComponents;

public abstract class RzComponentBase : ComponentBase, IRzRefreshableView
{
    [Inject] protected ObjectPool<StringBuilder> StringBuilderPool { get; set; } = null!;

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    /// <summary>
    /// 获得/设置 用户自定义属性
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IDictionary<string, object>? AdditionalAttributes { get; set; }


    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    public async void RefreshView()
    {
        await InvokeAsync(() => StateHasChanged());
    }
}

