using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CS_SmallWorld;

namespace Appli_SmallWorld
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PartieConcret _partie;
        Plateau _plateau;

        public MainWindow()
        {
            InitializeComponent();
            System.Collections.Generic.Dictionary<String, int> players = new System.Collections.Generic.Dictionary<String, int>();

            players.Add("Tom", 1);
            players.Add("Fab", 2);
            _partie = new PartieConcret(25, players);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // on initialise la Grid (mapGrid défini dans le xaml) à partir de la map du modèle (engine)
            _plateau = _partie.Plateau;
            for (int c = 0; c < _plateau.Taille; c++)
            {
                plateauGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50, GridUnitType.Pixel) });
            }
            for (int l = 0; l < _plateau.Taille; l++)
            {
                plateauGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(50, GridUnitType.Pixel) });
                for (int c = 0; c < _plateau.Taille; c++)
                {
                    // dans chaque case de la grille on ajoute une tuile (logique) matérialisée par un rectangle (physique)
                    // le rectangle possède une référence sur sa tuile
                    var bonusCase = _plateau.getCaseAt(new Position(c, l));
                    var element = createCaseGrid(c, l, bonusCase);
                    plateauGrid.Children.Add(element);
                }
            }
            //updateUnitUI();
        }

        private Rectangle createCaseGrid(int c, int l, BonusCase bonusCase)
        {
            var rectangle = new Rectangle();
            if (bonusCase.TCase is CaseMontagne)
                rectangle.Fill = Brushes.Brown;
            if (bonusCase.TCase is CaseForet)
                rectangle.Fill = Brushes.DarkGreen;
            if (bonusCase.TCase is CaseEau)
                rectangle.Fill = Brushes.SlateBlue;
            if (bonusCase.TCase is CasePlaine)
                rectangle.Fill = Brushes.LightGreen;
            if (bonusCase.TCase is CaseDesert)
                rectangle.Fill = Brushes.Yellow;
            // mise à jour des attributs (column et Row) référencant la position dans la grille à rectangle
            Grid.SetColumn(rectangle, c);
            Grid.SetRow(rectangle, l);
            rectangle.Tag = bonusCase; // Tag : ref par defaut sur la tuile logique

            rectangle.Stroke = Brushes.Black;
            rectangle.StrokeThickness = 0.5;
            // enregistrement d'un écouteur d'evt sur le rectangle : 
            // source = rectangle / evt = MouseLeftButtonDown / délégué = rectangle_MouseLeftButtonDown
            //rectangle.MouseLeftButtonDown += new MouseButtonEventHandler(rectangle_MouseLeftButtonDown);
            return rectangle;
        }


    }


}
