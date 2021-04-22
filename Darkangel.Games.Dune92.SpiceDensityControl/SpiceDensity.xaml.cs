using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Darkangel.Games.Dune92
{
    /// <summary>
    /// Логика взаимодействия для SpiceDensity.xaml
    /// </summary>
    public partial class SpiceDensity : UserControl
    {
        const int CellCount = 16;
        const int OneCellCost = 17;
        const int MinCellIndex = 0;
        const int MaxCellIndex = CellCount - 1;
        const int MaxValue = OneCellCost * MaxCellIndex;
        const int MinValue = 0;

        private int _Index = 0;
        private void SetIndex(int value)
        {
            value %= CellCount;

            if (_Index != value)
            {
                foreach (var el in DensityPanel.Children)
                {
                    if (el is Button btn)
                    {
                        if (btn.TabIndex == _Index)
                        {
                            btn.BorderBrush = Brushes.Transparent;
                        }
                        else if (btn.TabIndex == value)
                        {
                            btn.BorderBrush = Brushes.Black;
                        }
                    }
                }
            }
            _Index = value;
        }
        public int Value
        {
            get => _Index * OneCellCost;
            set
            {
                if (value > MaxValue)
                {
                    _Index = MaxCellIndex;
                }
                else if (value < MinValue)
                {
                    _Index = MinCellIndex;
                }
                else
                {
                    var num = value / OneCellCost;
                    if (((value % OneCellCost) / 2) > 8) num++;
                    SetIndex(num);
                }
            }
        }
        public SpiceDensity()
        {
            InitializeComponent();
        }

        private void Density_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button bt)
            {
                SetIndex(bt.TabIndex);
            }
        }
    }
}
