using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

// SqlContext 擴充方法類別
public static class SqlDbExtensions
{
    /// <summary>
    /// 呼叫選擇form回傳 T 實體(可用表達式篩選)
    /// </summary>
    public static T Selector<T>(this DbSet<T> dbSet,
        Expression<Func<T, bool>> filter = null) where T : class
    {
        var query = dbSet.AsQueryable();
        if (filter != null)
            query = query.Where(filter);

        T selectedEntity = null;  //  儲存選擇的實體

        //  呼叫泛型實體選擇視窗
        using (var form = new Select_Form<T>(query.ToList()))
        {
            //  設定回調函數，取得選擇結果
            form.OnEntitySelected = (entity) =>
            {
                selectedEntity = entity;  // 將選擇的實體存起來
            };

            //  顯示選擇form
            form.ShowDialog();
        }

        return selectedEntity;  //  返回選擇的實體（若無選擇返回 null）
    }
}
