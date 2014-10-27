namespace TestFramework.Core.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArtOfTest.WebAii.Controls;
    using ArtOfTest.WebAii.Core;

    public static class FindExtensions
    {
        public static TControl ByClassName<TControl>(this Find find, string target) where TControl : Control, new()
        {
            return find.ByExpression<TControl>(string.Concat("class=", target));
        }

        public static ICollection<TControl> AllByTitleContent<TControl>(this Find find, string target) where TControl : Control, new()
        {
            return find.AllByAttributes<TControl>(string.Concat("title=~", target));
        }
    }
}