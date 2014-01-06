
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
        Unite _uniteSelect;
        Dictionary<Unite, Ellipse> _troupes;

        public MainWindow()
        {
            InitializeComponent();
            System.Collections.Generic.Dictionary<String, int> players = new System.Collections.Generic.Dictionary<String, int>();


            players.Add("Tom", 1);
            players.Add("Fab", 2);
            _partie = new PartieConcret(5, players);
            eltPartie.Tag = _partie; // permet le binding des infos contenues dans la partie
            _uniteSelect = null;
            _troupes = new Dictionary<Unite, Ellipse>();
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
                    scoreJ1.Content = 0;
                    scoreJ2.Content = 0;
                }
            }

            foreach (JoueurConcret j in _partie.Joueurs)
            {
                foreach (Unite u in j.Troupes)
                {
                    placerUnite(u, j.Peuple);
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
                rectangle.Fill = Brushes.DarkGoldenrod;
            // mise à jour des attributs (column et Row) référencant la position dans la grille à rectangle
            Grid.SetColumn(rectangle, c);
            Grid.SetRow(rectangle, l);
            rectangle.Tag = bonusCase; // Tag : ref par defaut sur la tuile logique

            rectangle.Stroke = Brushes.Black;
            rectangle.StrokeThickness = 0.5;
            // enregistrement d'un écouteur d'evt sur le rectangle : 
            // source = rectangle / evt = MouseLeftButtonDown / délégué = rectangle_MouseLeftButtonDown
            rectangle.MouseLeftButtonDown += new MouseButtonEventHandler(rectangle_MouseLeftButtonDown);
            return rectangle;
        }

        private Ellipse placerUnite(Unite u,Peuple peuple)
        {
            int c = u.CaseCourante.Position.X;
            int l = u.CaseCourante.Position.Y;
            var ellipseUnite = new Ellipse();
            if (peuple is PeupleGauloisConcret)
                     ellipseUnite.Fill = Brushes.Blue;
            else if (peuple is PeupleNainConcret)
                    ellipseUnite.Fill = Brushes.Red;
            else if (peuple is PeupleVikingConcret)
                    ellipseUnite.Fill = Brushes.Yellow;
            ellipseUnite.Height = 25;
            ellipseUnite.Width = 25;
            Grid.SetColumn(ellipseUnite, c);
            Grid.SetRow(ellipseUnite, l);

            ellipseUnite.Tag = u;
            plateauGrid.Children.Add(ellipseUnite);

            ellipseUnite.MouseLeftButtonDown += new MouseButtonEventHandler(ellipseUnite_MouseLeftButtonDown);
            
            _troupes.Add(u, ellipseUnite);
            
            return ellipseUnite;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Cette fonction est appelée AVANT celle sur le rectangle donc
            //permet d'enlever le focus sur l'ancienne caseAnalysee avant
            //de le mettre via l'handler sur rectangle sur la nouvelle
            caseAnalysee.Tag = null;
            caseAnalysee.Visibility = System.Windows.Visibility.Collapsed;

            UniteSelectionnee.Tag = null;
            UniteSelectionnee.Visibility = System.Windows.Visibility.Collapsed;
        }

        void rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var rectangle = sender as Rectangle;
            var bonusCase = rectangle.Tag as BonusCase;

            int c = Grid.GetColumn(rectangle);
            int r = Grid.GetRow(rectangle);

            Grid.SetColumn(caseAnalysee, c);
            Grid.SetRow(caseAnalysee, r);

            caseAnalysee.Tag = bonusCase;

            Unite oqp = bonusCase.getMeilleureUnite();
            //deplacement d'unite
            if (_uniteSelect != null)
            {
                if (_uniteSelect.utiliserUnite(bonusCase))
                {
                    UniteSelectionnee.Visibility = System.Windows.Visibility.Hidden;
                    Grid.SetColumn(_troupes[_uniteSelect], c);
                    Grid.SetRow(_troupes[_uniteSelect], r);
                    Grid.SetColumn(UniteSelectionnee, c);
                    Grid.SetRow(UniteSelectionnee, r);
                }

                if (_uniteSelect.PV == 0)
                {
                    _troupes[_uniteSelect].Visibility = System.Windows.Visibility.Hidden;
                    _troupes.Remove(_uniteSelect);
                }

                if ( (oqp != null) && oqp.PV == 0)
                {
                    _troupes[oqp].Visibility = System.Windows.Visibility.Hidden;
                    _troupes.Remove(oqp);
                    oqp = null;
                }
                _uniteSelect = null; // remise à zéro après utilisation
            }
            else
            {   //analyse de la case s'il n'y a pas d'unite selectionnee
                caseAnalysee.Visibility = System.Windows.Visibility.Visible;

                if (oqp == null)
                    occupeePar.Content = "personne";
                else
                    occupeePar.Content = oqp.Joueur.Name;
            }
        }

        void ellipseUnite_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var ellipse = sender as Ellipse;
            var unite = ellipse.Tag as Unite;
            if(unite.Joueur == _partie.JoueurCourant)
                _uniteSelect = unite;

            //met à jour la surbrillance de l'unité sélectionnée
            int c = Grid.GetColumn(ellipse);
            int r = Grid.GetRow(ellipse);
            Grid.SetColumn(UniteSelectionnee, c);
            Grid.SetRow(UniteSelectionnee, r);

            UniteSelectionnee.Tag = unite;
            UniteSelectionnee.Visibility = System.Windows.Visibility.Visible;
        }

        private void FinTour_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            bool continuer = _partie.finirTour();
            scoreJ1.Content = _partie.Joueurs[0].Score;
            scoreJ2.Content = _partie.Joueurs[1].Score;

            //if (!continuer)
                //TODO: finir la partie
        }

        private void FinTour_Click(object sender, RoutedEventArgs e)
        {
            _partie.finirTour();
            scoreJ1.Content = _partie.Joueurs[0].Score;
            scoreJ2.Content = _partie.Joueurs[1].Score;
        }

    }


}
