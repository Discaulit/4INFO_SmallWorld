
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
        Dictionary<Unite, Grid> _troupes;
        SolidColorBrush _gauloisColor = Brushes.DarkBlue;
        SolidColorBrush _nainColor = Brushes.DarkRed;
        SolidColorBrush _vikingColor = Brushes.DarkOrange;

        public MainWindow()
        {
            InitializeComponent();

            this.Background = new ImageBrush(new BitmapImage(new Uri(@"..\..\..\ressources\background.jpg", UriKind.Relative)));
            zoneDeJeu.Background = new ImageBrush(new BitmapImage(new Uri(@"..\..\..\ressources\map_background.png", UriKind.Relative)));
        }

        private Grid createCaseGrid(int c, int l, BonusCase bonusCase)
        {
            System.Windows.Media.ImageBrush imgMontagne = new ImageBrush();
            imgMontagne.ImageSource = new BitmapImage(new Uri(@"..\..\..\ressources\terrain\montagne.jpg", UriKind.Relative));
            System.Windows.Media.ImageBrush imgForet = new ImageBrush();
            imgForet.ImageSource = new BitmapImage(new Uri(@"..\..\..\ressources\terrain\foret.jpg", UriKind.Relative));
            System.Windows.Media.ImageBrush imgEau = new ImageBrush();
            imgEau.ImageSource = new BitmapImage(new Uri(@"..\..\..\ressources\terrain\eau.jpg", UriKind.Relative));
            System.Windows.Media.ImageBrush imgPlaine = new ImageBrush();
            imgPlaine.ImageSource = new BitmapImage(new Uri(@"..\..\..\ressources\terrain\plaine.jpg", UriKind.Relative));
            System.Windows.Media.ImageBrush imgDesert = new ImageBrush();
            imgDesert.ImageSource = new BitmapImage(new Uri(@"..\..\..\ressources\terrain\desert.jpg", UriKind.Relative));

            var rectangle = new Rectangle();
            if (bonusCase.TCase is CaseMontagne)
                rectangle.Fill = imgMontagne; //Brushes.Brown;
            if (bonusCase.TCase is CaseForet)
                rectangle.Fill = imgForet;//Brushes.DarkGreen;
            if (bonusCase.TCase is CaseEau)
                rectangle.Fill = imgEau; //Brushes.SlateBlue;
            if (bonusCase.TCase is CasePlaine)
                rectangle.Fill = imgPlaine; //Brushes.LightGreen;
            if (bonusCase.TCase is CaseDesert)
                rectangle.Fill = imgDesert; //Brushes.DarkGoldenrod;

            rectangle.Stroke = Brushes.Black;
            rectangle.StrokeThickness = 0.5;

            var g = new Grid();
            // enregistrement d'un écouteur d'evt sur le rectangle : 
            // source = rectangle / evt = MouseLeftButtonDown / délégué = rectangle_MouseLeftButtonDown
            g.MouseLeftButtonDown += new MouseButtonEventHandler(rectangle_MouseLeftButtonDown);

            // mise à jour des attributs (column et Row) référencant la position dans la grille à rectangle
            Grid.SetColumn(g, c);
            Grid.SetRow(g, l);
            g.Tag = bonusCase; // Tag : ref par defaut sur la tuile logique

            g.Children.Add(rectangle);

            return g;
        }

        private void placerUnite(Unite u, Peuple peuple)
        {
            int c = u.CaseCourante.Position.X;
            int l = u.CaseCourante.Position.Y;
            var ellipseUnite = new Ellipse();
            var gridUnite = new Grid();

            if (peuple is PeupleGauloisConcret)
                ellipseUnite.Fill = _gauloisColor;
            else if (peuple is PeupleNainConcret)
                ellipseUnite.Fill = _nainColor;
            else if (peuple is PeupleVikingConcret)
                ellipseUnite.Fill = _vikingColor;
            ellipseUnite.Height = 25;
            ellipseUnite.Width = 25;

            gridUnite.Children.Add(ellipseUnite);
            gridUnite.Tag = u;

            var nbrUnite = new TextBlock();
            nbrUnite.TextAlignment = TextAlignment.Center;
            nbrUnite.VerticalAlignment = VerticalAlignment.Center;
            nbrUnite.Foreground = Brushes.White;
            nbrUnite.FontWeight = FontWeights.UltraBold;
            nbrUnite.FontSize = 15;
            nbrUnite.Text = u.CaseCourante.UnitesPresentes.Count.ToString();

            gridUnite.Children.Add(nbrUnite);

            Grid.SetColumn(gridUnite, c);
            Grid.SetRow(gridUnite, l);
            plateauGrid.Children.Add(gridUnite);

            gridUnite.MouseLeftButtonDown += new MouseButtonEventHandler(ellipseUnite_MouseLeftButtonDown);

            _troupes.Add(u, gridUnite);
        }

        private void RefreshNbrUnite()
        {
            foreach (var pair in _troupes)
            {
                if (pair.Value.Children[1] is TextBlock)
                {
                    TextBlock t = (TextBlock)pair.Value.Children[1];
                    t.Text = pair.Key.CaseCourante.UnitesPresentes.Count.ToString();
                }
            }
        }

        private void RefreshColorJoueurCourant()
        {
            JCourant.Foreground = GetColorJoueur(_partie.JoueurCourant);
        }

        private SolidColorBrush GetColorJoueur(Joueur j)
        {
            if (j.Peuple is PeupleGauloisConcret)
            {
                return _gauloisColor;
            }
            else
            {
                if (j.Peuple is PeupleNainConcret)
                {
                    return _nainColor;
                }
                else
                {
                    return _vikingColor;
                }
            }
        }

        private void Dock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Fin_tour();
            }
        }

        private void DeSurbrillanceCasesPossible()
        {
            foreach (Grid g in plateauGrid.Children)
            {
                if (g.Children[0] is Rectangle)
                {
                    g.Children[0].Opacity = 1;
                }
            }
        }

        private void SurbrillanceCasesPossible(Unite unite)
        {
            foreach (Grid g in plateauGrid.Children)
            {
                if (g.Children[0] is Rectangle && g.Tag != null)
                {
                    if (!unite.caseAccessible((BonusCase)g.Tag))
                        g.Children[0].Opacity = 0.5;
                }
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Cette fonction est appelée AVANT celle sur le rectangle donc
            //permet d'enlever le focus sur l'ancienne caseAnalysee avant
            //de le mettre via l'handler sur rectangle sur la nouvelle
            caseAnalysee.Tag = null;
            caseAnalysee.Visibility = System.Windows.Visibility.Collapsed;

            DeselectionUnite();
        }

        void rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var grid = sender as Grid;
            var bonusCase = grid.Tag as BonusCase;

            int c = Grid.GetColumn(grid);
            int r = Grid.GetRow(grid);

            Grid.SetColumn(caseAnalysee, c);
            Grid.SetRow(caseAnalysee, r);

            caseAnalysee.Tag = bonusCase;

            Unite oqp = bonusCase.getMeilleureUnite();
            //deplacement d'unite
            if (_uniteSelect != null)
            {
                if (_uniteSelect.utiliserUnite(bonusCase))
                {
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

                if ((oqp != null) && oqp.PV == 0)
                {
                    _troupes[oqp].Visibility = System.Windows.Visibility.Hidden;
                    _troupes.Remove(oqp);
                    oqp = null;
                }
            }
            else
            {   //analyse de la case s'il n'y a pas d'unite selectionnee
                caseAnalysee.Visibility = System.Windows.Visibility.Visible;

                if (oqp == null)
                {
                    occupant.Content = "personne";
                }
                else
                {
                    occupant.Content = oqp.Joueur.Name;
                }
            }

            DeselectionUnite();
            RefreshNbrUnite();
        }

        private void SelectionUnite(Unite unite, Grid grid)
        {
            DeSurbrillanceCasesPossible();

            //met à jour la surbrillance de l'unité sélectionnée
            int c = Grid.GetColumn(grid);
            int r = Grid.GetRow(grid);
            Grid.SetColumn(UniteSelectionnee, c);
            Grid.SetRow(UniteSelectionnee, r);

            //surbrillance des cases possibles de déplacement
            SurbrillanceCasesPossible(unite);

            UniteSelectionnee.Tag = unite;
            UniteSelectionnee.Visibility = System.Windows.Visibility.Visible;
        }

        private void DeselectionUnite()
        {
            DeSurbrillanceCasesPossible();

            _uniteSelect = null;
            UniteSelectionnee.Tag = null;
            UniteSelectionnee.Visibility = System.Windows.Visibility.Hidden;
        }

        void ellipseUnite_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var grid = sender as Grid;
            var unite = grid.Tag as Unite;

            if (unite == (Unite)UniteSelectionnee.Tag)
            {
                DeselectionUnite();
            }
            else
            {
                SelectionUnite(unite, grid);

                if (unite.Joueur == _partie.JoueurCourant)
                {
                    _uniteSelect = unite;
                }
            }

        }


        private void FinTour_Click(object sender, RoutedEventArgs e)
        {
            Fin_tour();
        }

        private void Fin_tour()
        {
            DeselectionUnite();
            bool continuer = _partie.finirTour();
            scoreJ1.Content = _partie.Joueurs[0].Score;
            scoreJ2.Content = _partie.Joueurs[1].Score;

            RefreshColorJoueurCourant();

            if (!continuer)
            {
                Joueur jGagnant = (_partie.Joueurs[0].Score > _partie.Joueurs[1].Score ? _partie.Joueurs[0] : _partie.Joueurs[1]);
                MessageBox.Show(jGagnant.Name + " a gagné !", "Fin de partie !");
            }
        }

        private void Joueur1_Click(object sender, RoutedEventArgs e)
        {
            if (partieTaille.SelectedIndex > -1)
            {
                dockInfoPartie.Visibility = System.Windows.Visibility.Collapsed;
                dockJoueur1.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Veuillez choisir une taille de partie.", "Error");
            }
        }

        private void Joueur2_Click(object sender, RoutedEventArgs e)
        {
            if (joueur1Peuple.SelectedIndex > -1 && !String.IsNullOrEmpty(joueur1Name.Text.Trim()))
            {
                joueur2Peuple.Items.RemoveAt(joueur1Peuple.Items.IndexOf(joueur1Peuple.SelectedItem));
                dockJoueur1.Visibility = System.Windows.Visibility.Collapsed;
                dockJoueur2.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Veuillez entrer un nom de joueur et choisir un peuple.", "Error");
            }
        }

        private void CreerPartie_Click(object sender, RoutedEventArgs e)
        {
            if (joueur2Peuple.SelectedIndex > -1 && !String.IsNullOrEmpty(joueur2Name.Text.Trim()))
            {
                if (joueur1Name.Text.Trim() == joueur2Name.Text.Trim())
                {
                    MessageBox.Show("Ce nom est déjà pris, veuillez en choisir un autre.", "Error");
                }
                else
                {
                    System.Collections.Generic.Dictionary<String, int> players = new System.Collections.Generic.Dictionary<String, int>();
                    players.Add(joueur1Name.Text.Trim(), Convert.ToInt32(joueur1Peuple.SelectedValue));
                    players.Add(joueur2Name.Text.Trim(), Convert.ToInt32(joueur2Peuple.SelectedValue));
                    _partie = new PartieConcret(Convert.ToInt32(partieTaille.SelectedValue), players);
                    eltPartie.Tag = _partie; // permet le binding des infos contenues dans la partie
                    _uniteSelect = null;
                    _troupes = new Dictionary<Unite, Grid>();

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

                    RefreshColorJoueurCourant();
                    labelJ1.Foreground = GetColorJoueur(_partie.Joueurs[0]);
                    labelJ2.Foreground = GetColorJoueur(_partie.Joueurs[1]);

                    // on passe à l'interface de partie
                    dockJoueur2.Visibility = System.Windows.Visibility.Collapsed;
                    dockPartie.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer un nom de joueur et choisir un peuple.", "Error");
            }
        }

    }


}
