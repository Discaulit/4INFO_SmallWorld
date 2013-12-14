﻿using System;
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


            // Affichage des noms des joueurs :
            labelJ1.Content = _partie.Joueurs.ElementAt(0).Name;
            scoreJ1.Content = 0;
            labelJ2.Content = _partie.Joueurs.ElementAt(1).Name;
            scoreJ2.Content = 0;

            foreach (JoueurConcret j in _partie.Joueurs)
            {
            
                foreach (Unite u in j.Troupes)
                {
                    var element = placerUnite(u.CaseCourante.Position.X, u.CaseCourante.Position.Y, j.Peuple);
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
                rectangle.Fill = Brushes.DarkGoldenrod;
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

        private Ellipse placerUnite(int c, int l, Peuple peuple)
        {
            var ellipseUnite = new Ellipse();
            if (peuple is PeupleGauloisConcret)
                     ellipseUnite.Fill = Brushes.Blue;
            else if (peuple is PeupleNainConcret)
                    ellipseUnite.Fill = Brushes.Red;
            else if (peuple is PeupleVikingConcret)
                    ellipseUnite.Fill = Brushes.Yellow;
            ellipseUnite.Visibility = System.Windows.Visibility.Collapsed;
            Grid.SetColumn(ellipseUnite, c);
            Grid.SetRow(ellipseUnite, l);

            ellipseUnite.Tag = _plateau.getCaseAt(new Position(c,l));
            return ellipseUnite;
        }
    }


}
