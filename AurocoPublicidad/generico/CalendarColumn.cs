using System;
using System.Windows.Forms;

public class CalendarColumn : DataGridViewColumn
{
    public CalendarColumn() : base(new CalendarCell())
    {
    }

    public override DataGridViewCell CellTemplate
    {
        get => base.CellTemplate;
        set
        {
            // Solo se permite CalendarCell como plantilla
            if (value != null && !value.GetType().IsAssignableFrom(typeof(CalendarCell)))
            {
                throw new InvalidCastException("Debe ser una CalendarCell.");
            }
            base.CellTemplate = value;
        }
    }
}

public class CalendarCell : DataGridViewTextBoxCell
{
    public CalendarCell() : base()
    {
        this.Style.Format = "dd/MM/yyyy";
    }

    public override void InitializeEditingControl(int rowIndex, object initialFormattedValue,
        DataGridViewCellStyle dataGridViewCellStyle)
    {
        base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

        CalendarEditingControl ctl = DataGridView.EditingControl as CalendarEditingControl;
        if (this.Value == null || this.Value == DBNull.Value)
        {
            ctl.Value = DateTime.Now;
        }
        else
        {
            ctl.Value = Convert.ToDateTime(this.Value);
        }
    }

    public override Type EditType => typeof(CalendarEditingControl);
    public override Type ValueType => typeof(DateTime);
    public override object DefaultNewRowValue => DateTime.Now;
}

public class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
{
    private DataGridView dataGridView;
    private bool valueChanged = false;
    private int rowIndex;

    public CalendarEditingControl()
    {
        this.Format = DateTimePickerFormat.Short;
    }

    public object EditingControlFormattedValue
    {
        get => this.Value.ToShortDateString();
        set
        {
            if (value is string dateString)
            {
                try
                {
                    this.Value = DateTime.Parse(dateString);
                }
                catch
                {
                    this.Value = DateTime.Now;
                }
            }
        }
    }

    public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        => EditingControlFormattedValue;

    public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
    {
        this.Font = dataGridViewCellStyle.Font;
        this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
        this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
    }

    public int EditingControlRowIndex
    {
        get => rowIndex;
        set => rowIndex = value;
    }

    public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
        => true;

    public void PrepareEditingControlForEdit(bool selectAll)
    {
    }

    public bool RepositionEditingControlOnValueChange => false;
    public DataGridView EditingControlDataGridView
    {
        get => dataGridView;
        set => dataGridView = value;
    }

    public bool EditingControlValueChanged
    {
        get => valueChanged;
        set => valueChanged = value;
    }

    public Cursor EditingPanelCursor => base.Cursor;

    protected override void OnValueChanged(EventArgs eventargs)
    {
        valueChanged = true;
        this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
        base.OnValueChanged(eventargs);
    }
}
