
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
        }

        private Rectangle createCaseGrid(int c, int l, BonusCase bonusCase)
        {
            System.Windows.Media.ImageBrush imgMontagne = new ImageBrush();
            imgMontagne.ImageSource = new BitmapImage(new Uri(@"..\..\Terrain\montagne1.jpg", UriKind.Relative));
            System.Windows.Media.ImageBrush imgForet = new ImageBrush();
            imgForet.ImageSource = new BitmapImage(new Uri(@"..\..\Terrain\foret2.jpg", UriKind.Relative));
            System.Windows.Media.ImageBrush imgEau = new ImageBrush();
            imgEau.ImageSource = new BitmapImage(new Uri(@"..\..\Terrain\mer1.jpg", UriKind.Relative));
            System.Windows.Media.ImageBrush imgPlaine = new ImageBrush();
            imgPlaine.ImageSource = new BitmapImage(new Uri(@"..\..\Terrain\herbe2.jpg", UriKind.Relative));
            System.Windows.Media.ImageBrush imgDesert = new ImageBrush();
            imgDesert.ImageSource = new BitmapImage(new Uri(@"..\..\Terrain\desert1.jpg", UriKind.Relative));

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

        private Ellipse placerUnite(Unite u, Peuple peuple)
        {
            int c = u.CaseCourante.Position.X;
            int l = u.CaseCourante.Position.Y;
            var ellipseUnite = new Ellipse();
            if (peuple is PeupleGauloisConcret)
                ellipseUnite.Fill = Brushes.Blue;
            else if (peuple is PeupleNainConcret)
                ellipseUnite.Fill = Brushes.Red;
            else if (peuple is PeupleVikingConcret)
                ellipseUnite.Fill = Brushes.Brown;
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

        private void Dock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Fin_tour();
            }
        }

        private void DeSurbrillanceCasesPossible()
        {
            foreach (Shape rt in plateauGrid.Children)
            {
                if (rt is Rectangle)
                {
                    rt.Opacity = 1;
                }
            }
        }

        private void SurbrillanceCasesPossible(Unite unite)
        {
            foreach (Shape rt in plateauGrid.Children)
            {
                if (rt is Rectangle && rt.Tag != null)
                {
                    if(!unite.caseAccessible((BonusCase)rt.Tag))
                        rt.Opacity = 0.5;
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

            UniteSelectionnee.Tag = null;
            DeSurbrillanceCasesPossible();
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

                if ((oqp != null) && oqp.PV == 0)
                {
                    _troupes[oqp].Visibility = System.Windows.Visibility.Hidden;
                    _troupes.Remove(oqp);
                    oqp = null;
                }
                _uniteSelect = null; // remise à zéro après utilisation
                DeSurbrillanceCasesPossible();
            }
            else
            {   //analyse de la case s'il n'y a pas d'unite selectionnee
                caseAnalysee.Visibility = System.Windows.Visibility.Visible;

                if (oqp == null)
                {
                    occupant.Content = "personne";
                    nbrUnitesCase.Content = 0;
                }
                else
                {
                    occupant.Content = oqp.Joueur.Name;
                    nbrUnitesCase.Content = bonusCase.UnitesPresentes.Count;
                }
            }
        }

        void ellipseUnite_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var ellipse = sender as Ellipse;
            var unite = ellipse.Tag as Unite;
            if (unite.Joueur == _partie.JoueurCourant)
                _uniteSelect = unite;

            DeSurbrillanceCasesPossible();

            //met à jour la surbrillance de l'unité sélectionnée
            int c = Grid.GetColumn(ellipse);
            int r = Grid.GetRow(ellipse);
            Grid.SetColumn(UniteSelectionnee, c);
            Grid.SetRow(UniteSelectionnee, r);

            //surbrillance des cases possibles de déplacement
            SurbrillanceCasesPossible(unite);

            UniteSelectionnee.Tag = unite;
            UniteSelectionnee.Visibility = System.Windows.Visibility.Visible;
        }


        private void FinTour_Click(object sender, RoutedEventArgs e)
        {
            Fin_tour();
        }

        private void Fin_tour()
        {
            bool continuer = _partie.finirTour();
            scoreJ1.Content = _partie.Joueurs[0].Score;
            scoreJ2.Content = _partie.Joueurs[1].Score;

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
                    _troupes = new Dictionary<Unite, Ellipse>();

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
