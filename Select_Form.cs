using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace XXX
{
    public partial class Select_Form<T> : Form
    {
        public Action<T> OnEntitySelected { get; set; }
        private List<T> _entities;
        //  建構函數
        public Select_Form(List<T> entities)
        {
            InitializeComponent();
            SetupColumn();
            _entities = entities;
            LOAD_DATA();
        }
        //  設定欄位
        private void SetupColumn()
        {
            //  可參考 https://objectlistview.sourceforge.net/cs/index.html 元件官網設定ObjectListView 欄位
        }
        //  撈資料
        private void LOAD_DATA()
        {
            if(_entities == null) return;

            // 塞資料
            olv.SetObjects(_entities);
        }
        //  連點,帶回資料模型實體
        private void olv_DoubleClick(object sender, EventArgs e)
        {
            if (!(olv.SelectedObject is T entity))
                return;

            //  回傳選定的實體資料模型
            OnEntitySelected?.Invoke(entity);

            //  關閉視窗
            this.Close();
        }
    }
}
