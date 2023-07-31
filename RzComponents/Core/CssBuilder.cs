using Microsoft.Extensions.ObjectPool;
using System.Text;

namespace RzComponents.Core;

public sealed class CssBuilder
{
    public static CssBuilder Create(ObjectPool<StringBuilder> strBuilderPool, string? value = null) => new(strBuilderPool, value);

    //------------------------------------------------
    private readonly StringBuilder stringBuilder;

    private readonly ObjectPool<StringBuilder> _strBuilderPool;
    private CssBuilder(ObjectPool<StringBuilder> strBuilderPool, string? value = null)
    {
        _strBuilderPool = strBuilderPool;

        stringBuilder = _strBuilderPool.Get();

        AddClass(value);
    }

    public CssBuilder AddClass(string? value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            if (stringBuilder.Length > 0)
                stringBuilder.Append(' ');

            stringBuilder.Append(value);
        }

        return this;
    }
    public CssBuilder AddClass(string? value, bool when = true) => when ? AddClass(value) : this;

    public CssBuilder ExtractClassFromAttributes(IDictionary<string, object>? additionalAttributes)
    {
        if (additionalAttributes?.TryGetValue("class", out var c) == true)
        {
            if (c is not null)
            {
                AddClass(c.ToString());
            }

            //additionalAttributes.Remove("class");
        }

        return this;
    }

    public CssBuilder ExtractStyleFromAttributes(IDictionary<string, object>? additionalAttributes)
    {
        if (additionalAttributes?.TryGetValue("style", out var c) == true)
        {
            if (c is not null)
            {
                var styleList = c.ToString();
                AddClass(styleList);
            }

            //additionalAttributes.Remove("style");
        }

        return this;
    }

    public string? Build()
    {
        var result = stringBuilder.Length > 0 ? stringBuilder.ToString() : null;

        _strBuilderPool.Return(stringBuilder);

        return result;
    }


}

