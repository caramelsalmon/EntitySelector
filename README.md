# EntitySelector
實體資料模型清單選擇器,傳入任何類型實體清單,返回選擇的實體.

範例使用微軟EF6(實體資料模型)及[ObjectListView第三方套件](https://objectlistview.sourceforge.net/cs/index.html)(用於呈現清單)

使用方法:

假設想從實體資料模型dAccTitle的清單中選擇一筆資料,並將選擇的實體屬性值賦予textbox.

泛型T 是 dAccTitle.

Filter 是可選參數 Expression<Func<T, bool>> ,可自定義篩選條件.


var dAccTitle = db.dAccTitle.Selector(Filter);  //  呼叫dAccTitle的選擇器,並返回選擇的實體

if (dAccTitle != null)
    textbox.Text = dAccTitle.name_c;            //  將選擇的實體屬性值賦予textbox
