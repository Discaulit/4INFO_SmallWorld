
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
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

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
        SolidColorBrush _gauloisColor = Brushes.DarkOliveGreen;
        SolidColorBrush _nainColor = Brushes.DarkSlateGray;
        SolidColorBrush _vikingColor = Brushes.DarkRed;
        Border _borderHighlighted;
        Ellipse _uniteHighlighted;
        Boolean _mainMenu;
        Microsoft.Win32.OpenFileDialog charger;
        Microsoft.Win32.SaveFileDialog sauvegarder;
        Grid atq;
        Boolean isOver = false;

        public MainWindow()
        {
            InitializeComponent();

            this.Background = new ImageBrush(new BitmapImage(new Uri(@"..\..\ressources\background.jpg", UriKind.Relative)));

            mainMenuPanel.Background = new ImageBrush(new BitmapImage(new Uri(@"..\..\ressources\menu_background.png", UriKind.Relative)));
            mainMenu.Background = new ImageBrush(new BitmapImage(new Uri(@"..\..\ressources\test.png", UriKind.Relative)));
            mainMenu.Background.Opacity = 0;

            dockInfoPartie.Background = new ImageBrush(new BitmapImage(new Uri(@"..\..\ressources\menu_background.png", UriKind.Relative)));
            dockJoueur1.Background = new ImageBrush(new BitmapImage(new Uri(@"..\..\ressources\menu_background.png", UriKind.Relative)));
            dockJoueur2.Background = new ImageBrush(new BitmapImage(new Uri(@"..\..\ressources\menu_background.png", UriKind.Relative)));

            backgroundMap.Background = new ImageBrush(new BitmapImage(new Uri(@"..\..\ressources\map_background.png", UriKind.Relative)));
            tourNum.Background = new ImageBrush(new BitmapImage(new Uri(@"..\..\ressources\tournum_panel.png", UriKind.Relative)));
            scoreJoueur1.Background = new ImageBrush(new BitmapImage(new Uri(@"..\..\ressources\score_panel.png", UriKind.Relative)));
            scoreJoueur2.Background = new ImageBrush(new BitmapImage(new Uri(@"..\..\ressources\score_panel.png", UriKind.Relative)));
            borderJ1.Background = new ImageBrush(new BitmapImage(new Uri(@"..\..\ressources\joueur_label2.png", UriKind.Relative)));
            borderJ2.Background = new ImageBrush(new BitmapImage(new Uri(@"..\..\ressources\joueur_label1.png", UriKind.Relative)));
            unitesCaseBorder.Background = new ImageBrush(new BitmapImage(new Uri(@"..\..\ressources\unitesCase_label.png", UriKind.Relative)));
            tourJ.Background = new ImageBrush(new BitmapImage(new Uri(@"..\..\ressources\joueurCourant.png", UriKind.Relative)));

            charger = new Microsoft.Win32.OpenFileDialog();
            sauvegarder = new Microsoft.Win32.SaveFileDialog();

            atq = new Grid();
            atq.Children.Add(new Ellipse());
            atq.Background = new ImageBrush(new BitmapImage(new Uri(@"..\..\ressources\attaque.png", UriKind.Relative)));
        }

        private Grid createCaseGrid(int c, int l, BonusCase bonusCase)
        {
            System.Windows.Media.ImageBrush imgMontagne = new ImageBrush();
            imgMontagne.ImageSource = new BitmapImage(new Uri(@"..\..\ressources\terrain\montagne.jpg", UriKind.Relative));
            System.Windows.Media.ImageBrush imgForet = new ImageBrush();
            imgForet.ImageSource = new BitmapImage(new Uri(@"..\..\ressources\terrain\foret.jpg", UriKind.Relative));
            System.Windows.Media.ImageBrush imgEau = new ImageBrush();
            imgEau.ImageSource = new BitmapImage(new Uri(@"..\..\ressources\terrain\eau.jpg", UriKind.Relative));
            System.Windows.Media.ImageBrush imgPlaine = new ImageBrush();
            imgPlaine.ImageSource = new BitmapImage(new Uri(@"..\..\ressources\terrain\plaine.jpg", UriKind.Relative));
            System.Windows.Media.ImageBrush imgDesert = new ImageBrush();
            imgDesert.ImageSource = new BitmapImage(new Uri(@"..\..\ressources\terrain\desert.jpg", UriKind.Relative));

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
            gridUnite.MouseEnter += new MouseEventHandler(unite_MouseEnter);
            gridUnite.MouseLeave += new MouseEventHandler(unite_MouseLeave);

            _troupes.Add(u, gridUnite);
        }

        private void unite_MouseEnter(object sender, MouseEventArgs e)
        {
            var grid = sender as Grid;
            var u = grid.Tag as Unite;

            if (_uniteSelect != null && !u.estAmie(_uniteSelect) && _uniteSelect.caseAccessible(u.CaseCourante))
            {
                grid.Children.Add(atq);
                atq.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void unite_MouseLeave(object sender, MouseEventArgs e)
        {
            var grid = sender as Grid;
            var u = grid.Tag as Unite;

            grid.Children.Remove(atq);            
            atq.Visibility = System.Windows.Visibility.Hidden;
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

            unitesJ1_1.Content = _partie.Joueurs[0].Troupes.Count + " unités";
            unitesJ2_1.Content = _partie.Joueurs[1].Troupes.Count + " unités";

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
            if (e.Key == Key.F1)
            {
                Process proc = new Process();
                proc.StartInfo = new ProcessStartInfo()
                {
                    FileName = "readme.pdf" //put your path here
                };
                proc.Start();
            }
            
            if (_partie != null)
            {
                if (e.Key == Key.Enter)
                {
                    Fin_tour();
                }
                if (e.Key == Key.Escape)
                {
                    afficher_mainmenu();
                }
            }
        }

        private void afficher_mainmenu()
        {
            if (_mainMenu)
            {
                mainMenu.Visibility = System.Windows.Visibility.Collapsed;
                mainMenu.Background.Opacity = 0;
                _mainMenu = false;
            }
            else
            {
                mainMenu.Visibility = System.Windows.Visibility.Visible;
                mainMenu.Background.Opacity = 0.7;
                _mainMenu = true;
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
        }

        private void combat(Grid grid)
        {         
            var bonusCase = grid.Tag as BonusCase;

            int c = Grid.GetColumn(grid);
            int r = Grid.GetRow(grid);

            Unite oqp = bonusCase.getMeilleureUnite();
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
                _uniteSelect = null;
            }

            if ((oqp != null) && oqp.PV == 0)
            {
                _troupes[oqp].Visibility = System.Windows.Visibility.Hidden;
                _troupes.Remove(oqp);
                oqp = null;
            }

            RefreshInfosPartie();
            if (_uniteSelect != null)
            {
                afficherUniteCase(_uniteSelect.CaseCourante);
            }
            else
            {
                unitesCaseBorder.Visibility = System.Windows.Visibility.Hidden;
                unitesCase.Children.Clear();
                DeSurbrillanceCasesPossible();
            }
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

            afficherUniteCase(bonusCase);

            //deplacement d'unite
            if (_uniteSelect != null)
            {
                combat(grid);
            }
            else
            {   //analyse de la case s'il n'y a pas d'unite selectionnee
                caseAnalysee.Visibility = System.Windows.Visibility.Visible;
            }

            DeselectionUnite();
            RefreshNbrUnite();
        }

        private void SelectionUnite(Unite unite)
        {
            DeSurbrillanceCasesPossible();

            //surbrillance des cases possibles de déplacement
            SurbrillanceCasesPossible(unite);
            SurbrillanceUnite(unite);

            UniteSelectionnee.Tag = unite;
            UniteSelectionnee.Visibility = System.Windows.Visibility.Visible;

            if (unite.Joueur == _partie.JoueurCourant)
            {
                _uniteSelect = unite;
            }
        }

        private void DeSurbrillanceUnite()
        {
            if (_uniteHighlighted != null)
            {
                _uniteHighlighted.StrokeThickness = 0;
            }
        }

        private void SurbrillanceUnite(Unite unite)
        {
            Grid g = GetGridUnite(unite);

            plateauGrid.Children.Remove(g);
            plateauGrid.Children.Add(g);

            var e = g.Children[0] as Ellipse;

            e.Stroke = Brushes.Yellow;
            e.StrokeThickness = 3;

            _uniteHighlighted = e;
        }

        private Grid GetGridUnite(Unite unite)
        {
            foreach (Grid g in plateauGrid.Children)
            {
                if (g.Tag == unite)
                {
                    return g;
                }
            }
            return null;
        }

        private Grid GetGridCaseUnite(Grid grid)
        {
            var u = grid.Tag as Unite;

            foreach (Grid g in plateauGrid.Children)
            {
                if (g.Tag is BonusCase && g.Tag == u.CaseCourante)
                {
                    return g;
                }
            }
            return null;
        }

        private void DeselectionUnite()
        {
            DeSurbrillanceCasesPossible();
            DeSurbrillanceUnite();
            uniteCase_deshighlight();

            _uniteSelect = null;
            UniteSelectionnee.Tag = null;
            UniteSelectionnee.Visibility = System.Windows.Visibility.Hidden;
        }

        private void afficherUniteCase(BonusCase c)
        {
            unitesCase.Children.Clear();
            if (c.getMeilleureUnite() == null)
            {
                unitesCaseBorder.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                unitesCaseBorder.Visibility = System.Windows.Visibility.Visible;
                unitesCasesTexte.Foreground = GetColorJoueur(c.getMeilleureUnite().Joueur);

                foreach (Unite u in c.UnitesPresentes)
                {
                    StackPanel unite = new StackPanel();

                    unite.Background = new ImageBrush(new BitmapImage(new Uri(@"..\..\ressources\hpmp_background.png", UriKind.Relative)));
                    unite.Margin = new Thickness(5);

                    StackPanel hps = new StackPanel();
                    hps.Orientation = Orientation.Horizontal;
                    hps.Width = 30 * 5;
                    hps.Height = 30;
                    hps.Margin = new Thickness(15, 10, 15, 10);

                    for (int i = 0; i < u.PV; i++)
                    {
                        Border hp = new Border();
                        hp.Background = new ImageBrush(new BitmapImage(new Uri(@"..\..\ressources\hp.png", UriKind.Relative)));
                        hp.Height = 30;
                        hp.Width = 30;
                        hps.Children.Add(hp);
                    }

                    for (int i = u.PV; i < 5; i++)
                    {
                        Border hp = new Border();
                        hp.Background = new ImageBrush(new BitmapImage(new Uri(@"..\..\ressources\hp2.png", UriKind.Relative)));
                        hp.Height = 30;
                        hp.Width = 30;
                        hps.Children.Add(hp);
                    }

                    unite.Children.Add(hps);

                    StackPanel mps = new StackPanel();
                    mps.Orientation = Orientation.Horizontal;
                    mps.Width = 30 * 5;
                    mps.Height = 30;
                    mps.Margin = new Thickness(15, 10, 15, 10);

                    for (int i = 0; i < u.PtsDeplacement; i++)
                    {
                        Border mp = new Border();
                        mp.Background = new ImageBrush(new BitmapImage(new Uri(@"..\..\ressources\mp.png", UriKind.Relative)));
                        mp.Height = 30;
                        mp.Width = 30;
                        mps.Children.Add(mp);
                    }

                    for (int i = u.PtsDeplacement; i < 2; i++)
                    {
                        Border mp = new Border();
                        mp.Background = new ImageBrush(new BitmapImage(new Uri(@"..\..\ressources\mp2.png", UriKind.Relative)));
                        mp.Height = 30;
                        mp.Width = 30;
                        mps.Children.Add(mp);
                    }

                    unite.Children.Add(mps);

                    Border border = new Border();
                    border.MouseLeftButtonDown += new MouseButtonEventHandler(unitesCase_MouseLeftButtonDown);
                    border.Tag = u;
                    border.Child = unite;

                    if (u == UniteSelectionnee.Tag)
                        uniteCase_highlight(border);

                    unitesCase.Children.Add(border);
                }
            }
        }

        private void unitesCase_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var border = sender as Border;
            var unite = border.Tag as Unite;

            if (unite == (Unite)UniteSelectionnee.Tag)
            {
                DeselectionUnite();
            }
            else
            {
                DeselectionUnite();
                uniteCase_highlight(border);
                SelectionUnite(unite);
            }

        }

        private void uniteCase_deshighlight()
        {
            if (_borderHighlighted != null)
            {
                _borderHighlighted.BorderThickness = new Thickness(0);
                _borderHighlighted.Background = null;
            }
        }

        private void uniteCase_highlight(Border b)
        {
            uniteCase_deshighlight();

            var u = b.Tag as Unite;

            b.BorderThickness = new Thickness(4);
            b.BorderBrush = Brushes.Goldenrod;
            b.CornerRadius = new CornerRadius(20);
            b.Background = GetColorJoueur(u.Joueur);

            _borderHighlighted = b;
        }

        private void ellipseUnite_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var grid = sender as Grid;
            var u = grid.Tag as Unite;

            Unite unite = u.CaseCourante.getMeilleureUnite();

            if (unite == (Unite)UniteSelectionnee.Tag)
            {
                DeselectionUnite();
            }
            else
            {
                if (_uniteSelect != null)
                {
                    combat(GetGridCaseUnite(grid));
                }
                else
                {
                    DeselectionUnite();
                    SelectionUnite(unite);
                    afficherUniteCase(unite.CaseCourante);
                }
            }
        }


        private void FinTour_Click(object sender, RoutedEventArgs e)
        {
            Fin_tour();
        }

        private void Fin_tour()
        {
            if (_partie != null)
            {
                DeselectionUnite();
                bool continuer = _partie.finirTour();
                RefreshInfosPartie();
                
                if (!continuer)
                {
                    FinPartie();
                }
            }
        }

        private void RefreshInfosPartie()
        {
            scoreJ1.Content = _partie.Joueurs[0].Score + " points";
            scoreJ2.Content = _partie.Joueurs[1].Score + " points";
            JCourant.Text = _partie.JoueurCourant.Name;
            tourRestant.Content = _partie.NumTour;

            RefreshColorJoueurCourant();
        }

        private void FinPartie()
        {
            Joueur jGagnant = (_partie.Joueurs[0].Score > _partie.Joueurs[1].Score ? _partie.Joueurs[0] : _partie.Joueurs[1]);
            var res = MessageBox.Show(jGagnant.Name + " a gagné !", "Fin de partie !", MessageBoxButton.OK);

            if (res == MessageBoxResult.OK)
            {
                dockPartie.Visibility = System.Windows.Visibility.Collapsed;
                mainMenu.Visibility = System.Windows.Visibility.Visible;

                _partie = null;
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
                ComboBoxItem a = (ComboBoxItem)joueur2Peuple.Items[joueur1Peuple.Items.IndexOf(joueur1Peuple.SelectedItem)];
                a.Visibility = System.Windows.Visibility.Collapsed;

                dockJoueur1.Visibility = System.Windows.Visibility.Collapsed;
                dockJoueur2.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Veuillez entrer un nom de joueur et choisir un peuple.", "Error");
            }
        }

        private void creerPartie()
        {
            eltPartie.Tag = _partie; // permet le binding des infos contenues dans la partie
            _uniteSelect = null;
            _troupes = new Dictionary<Unite, Grid>();

            // on initialise la Grid (mapGrid défini dans le xaml) à partir de la map du modèle (engine)
            _plateau = _partie.Plateau;

            plateauGrid.Children.Clear();
            plateauGrid.RowDefinitions.Clear();
            plateauGrid.ColumnDefinitions.Clear();
            
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

            foreach (JoueurConcret j in _partie.Joueurs)
            {
                foreach (Unite u in j.Troupes)
                {
                    placerUnite(u, j.Peuple);
                }
            }
            //updateUnitUI();

            scoreJ1.Content = "0 points";
            scoreJ2.Content = "0 points";

            RefreshNbrUnite();
            RefreshColorJoueurCourant();
            labelJ1.Foreground = GetColorJoueur(_partie.Joueurs[0]);
            labelJ2.Foreground = GetColorJoueur(_partie.Joueurs[1]);

            //marges de la zone de jeu
            Double x = 0;
            Double y = 0;

            switch (_plateau.Taille)
            {
                case 5:
                    y = 100;
                    break;
                case 10:
                    y = 125;
                    break;
                case 15:
                    y = 175;
                    break;
                default:
                    y = 100;
                    break;
            }

            x = 1.1 * y + 0.05 * _plateau.Taille * 50;
            carte.Margin = new Thickness(x, y, x, y);
        }

        private void fincreerPartie_Click(object sender, RoutedEventArgs e)
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

                    creerPartie();

                    ComboBoxItem a = (ComboBoxItem)joueur2Peuple.Items[joueur1Peuple.Items.IndexOf(joueur1Peuple.SelectedItem)];
                    a.Visibility = System.Windows.Visibility.Visible;            

                    // on passe à l'interface de partie
                    dockInfoPartie.Visibility = System.Windows.Visibility.Visible;
                    dockJoueur1.Visibility = System.Windows.Visibility.Collapsed;
                    dockJoueur2.Visibility = System.Windows.Visibility.Collapsed;

                    creationPartie.Visibility = System.Windows.Visibility.Collapsed;
                    dockPartie.Visibility = System.Windows.Visibility.Visible;

                    RefreshInterface();
                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer un nom de joueur et choisir un peuple.", "Error");
            }
        }

        private void nouvellePartie_Click(object sender, RoutedEventArgs e)
        {
            dockPartie.Visibility = System.Windows.Visibility.Collapsed;
            mainMenu.Visibility = System.Windows.Visibility.Collapsed;
            creationPartie.Visibility = System.Windows.Visibility.Visible;
        }

        private void chargerPartie_Click(object sender, RoutedEventArgs e)
        {
            _partie = null;

            Nullable<bool> result = charger.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                // Open document 
                string filename = charger.FileName;

                Stream stream = File.Open(filename, FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();

                _partie = (PartieConcret)formatter.Deserialize(stream);
                stream.Close();

                creerPartie();

                // on passe à l'interface de partie
                mainMenu.Visibility = System.Windows.Visibility.Collapsed;
                dockInfoPartie.Visibility = System.Windows.Visibility.Visible;
                dockJoueur1.Visibility = System.Windows.Visibility.Collapsed;
                dockJoueur2.Visibility = System.Windows.Visibility.Collapsed;

                creationPartie.Visibility = System.Windows.Visibility.Collapsed;
                dockPartie.Visibility = System.Windows.Visibility.Visible;

                RefreshInterface();
            }                       
        }

        private void RefreshInterface()
        {
            RefreshColorJoueurCourant();
            RefreshNbrUnite();
            RefreshInfosPartie();
        }

        private void quitter_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();            
        }

        private void sauvegarderPartie_Click(object sender, RoutedEventArgs e)
        {
            if (_partie == null)
                MessageBox.Show("Pas de partie en cours à sauvegarder !");
            else
            {
                Nullable<bool> result = sauvegarder.ShowDialog();

                if (result == true)
                {
                    string filename = sauvegarder.FileName;

                    Stream stream = File.Open(filename, FileMode.Create);
                    BinaryFormatter formatter = new BinaryFormatter();

                    formatter.Serialize(stream, _partie);
                    stream.Close();
                }

            }
        }
    }
}
