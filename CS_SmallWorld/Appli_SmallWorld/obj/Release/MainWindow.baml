   M S B A M L   `   `   `  ����   Appli_SmallWorld!    Appli_SmallWorld.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     �Name$  
mainWindow�� � Title$ SmallWorld - INSA�� � WindowState$ 	Maximized=� � 	Resources  �� 
TargetType   styleCaseSelect �� Property �� Value  styleUniteSelect��%V  &	        &	 �     �� " ��.���  � ��$ 50����  � ��$ 50����  � ��
 �  ����  � ��$ 1����  �@K�ZIndex$	 333����  � y�$ 	Collapsed=��� " A�.���  � ��$ 25����  � ��$ 25����  � ��
 � �����  � ��$ 5����  �@K�ZIndex$	 333����  � y�$ 	Collapsed=�.��� -    �Name$ dockMainWindow��.+�� -   $ creationPartie��$��Center=�$��Center=�$	��430��$	��470��$y�	Collapsed=�.+�]� -    ]�Name$ dockInfoPartie��.+��� -   	 ��Name$	 partie��$��Center=�.+��� -   
 ��Name$
 partieTailleLabel��$��Taille partie��$��
Old London)�$
��Bold"�$��60(�
���-R��$��0,5,0,17q��� -   $��partieTaille�� �� SelectedValuePath$	 Tag��$��	0,0,0,207q�$��
Old London)�$
��Bold"�
�������
������ $��Center=�$��40(�.@��� $
��Demo��
 � Tag$ 5��
��������� $��Petite��$ 10��
��������� $��Normale��$ 15��
��������� -    ��Name$ Joueur1��$��Suivant��$��
Old London)�$
��Bold"�
���-R��$��40(�
������ ]� -	   $ dockJoueur1��$y�	Collapsed=�.+��� -
   $	 joueur1��$��Center=�.+��� -   $
 joueur1NameLabel��$��Nom joueur 1��$��
Old London)�$
��Bold"�$��60(�
���-R��$��0,5,0,17q��� -    ��Name$ joueur1Name�� �� TextWrapping$
 Wrap=�$�� ��$��
Old London)�$
��Bold"�$��40(�
�������
������  �� TextAlignment$ Center=�$��0,0,0,20q��� -   $
 joueur1PeupleLabel��$��Peuple joueur 1��$��
Old London)�$
��Bold"�$��60(�
���-R��$��0,0,0,25q��� -   $��joueur1Peuple��$	 Tag��$��
Old London)�$
��Bold"�$��40(�
�������
������ $��Center=�$��0,0,0,35q�.@��� $��Gaulois��$ 1��
���/kU��� $
��Nain��$ 2��
���OO/��� $��Viking��$ 3��
���  ���� -   $ Joueur2��$��Suivant��$��
Old London)�$
��Bold"�
���-R��
������ $��40(�]� -   $ dockJoueur2��$y�	Collapsed=�.+��� -   $	 joueur2��$��Center=�.+��� -   $
 joueur2NameLabel��$��Nom joueur 2��$��
Old London)�$
��Bold"�$��60(�
���-R��$��0,5,0,17q��� -   $ joueur2Name��$
 Wrap=�$�� ��$��
Old London)�$
��Bold"�$��40(�
�������
������ $ Center=�$��0,0,0,20q��� -   $
 joueur2PeupleLabel��$��Peuple joueur 2��$��
Old London)�$
��Bold"�$��60(�
���-R��$��0,0,0,25q��� -   $��joueur2Peuple��$	 Tag��$��
Old London)�$
��Bold"�$��40(�
�������
������ $��Center=�$��0,0,0,35q�.@��� $��Gaulois��$ 1��
���/kU��� $
��Nain��$ 2��
���OO/��� $��Viking��$ 3��
���  ���� -   $ CreerPartie��$��Créer Partie��$��
Old London)�$
��Bold"�
���-R��
������ $��40(�]� -   $ 
dockPartie��$y�	Collapsed=���.  � DataContext �� *Tag+ �� ElementName$ 	eltPartie��.+�A� -    A�Name$ 	eltPartie��$y�Hidden=��� -    ��Name$ bandeauG��$
��Left=�$
��Auto=�.���� .+��� -   $	 scoresJoueurs��.+��� -    ��Name$ borderJ1��._��� -   $
 labelJ1��$��
Old London)�$
��Bold"�$��60(�$��Center=�$��Center=�$��0,0,0,15q����� *Joueurs[0].Name+�� -   $	 scoreJoueur1��$��0,0,0,30q�.+��� -   $
 scoreJ1��$��
Old London)�$
��Bold"�$��40(�
�������$��Center=�$��Center=�$��
50,3,50,57q��� -   $
 
unitesJ1_1��$��
Old London)�$
��Bold"�$��40(�
�������$��Center=�$��Center=�$��	50,0,50,0q��� -    $
 
unitesJ1_2��$��	restantes��$��
Old London)�$
��Bold"�$��40(�
�������$��Center=�$��Center=�$��	50,0,50,5q��� -!   $ borderJ2��._��� -"   $
 labelJ2��$��
Old London)�$
��Bold"�$��60(�$��Center=�$��Center=�$��0,0,0,15q����� *Joueurs[1].Name+�� -#   $	 scoreJoueur2��$��0,0,0,30q�.+��� -$   $
 scoreJ2��$��
Old London)�$
��Bold"�$��40(�
�������$��Center=�$��Center=�$��
50,3,50,57q��� -%   $
 
unitesJ2_1��$��
Old London)�$
��Bold"�$��40(�
�������$��Center=�$��Center=�$��	50,0,50,0q��� -&   $
 
unitesJ2_2��$��	restantes��$��
Old London)�$
��Bold"�$��40(�
�������$��Center=�$��Center=�$��	50,0,50,5q��� -'   $	 tourNum��.+��� -(   $
 phTourPartie��$
��Tour��$��
Old London)�$
��Bold"�$��50(�$��Center=�
��� ���$��50,40,50,10q���  �� Orientation$ 
Horizontal=�$��Center=�$��50,10,50,40q�.+��� -)   $
 tourRestant��$��
Old London)�$
��Bold"�$��50(�
��� ������� *	NumTour+�� -*   $	
 sur��$��/��$��
Old London)�$
��Bold"�$��50(�
��� ����� -+   $
 tourMax��$��
Old London)�$
��Bold"�$��50(�
��� ������� *	NbTourMax+�� -,   $ bandeauD��$��Right=�$
��Auto=�$	��220��.���� .+��� --   $ unitesCaseBorder��$y�Hidden=�$��0,0,0,20q�._��� -.    ��Name$ unitesCasesTexte��$��
Old London)�$
��Bold"�$��40(�$��	0,20,0,20q� �� TextAlignment$ Center=�	Unités�� 
Présentes�� -/   $	 
unitesCase���� -0   $	 tourJ��$ 
Horizontal=�$��Center=�$	��Top=�.+��� -1   $ phTourJ1��$��	C'est à ��$��
Old London)�$
��Bold"�$��60(�
���-R��$��
70,10,0,20q��� -2   $ JCourant��$��
Old London)�$
��Bold"�$��60(�$��	0,10,0,20q����� *JoueurCourant.Name+�� -3   $ phTourJ2��$�� de jouer !��$��
Old London)�$
��Bold"�$��60(�
���-R��$��
0,10,70,20q��� -4   $��	zoneDeJeu��$
��Auto=�$
��Auto=�$��Center=�$��Center=�.���� -5   $��backgroundMap��._��� -6   $��carte��$
��Auto=�$
��Auto=�$��Center=�$��Center=�.��� -7   $��plateauGrid��.+�� -8   $��caseAnalysee��.+��� #��[  � -9   $��UniteSelectionnee��.+�A� #��[ � -:   $ mainMenu��.+��� -;   $	 mainMenuPanel��$��Center=�$��Center=�$	��430��$	��470��.+��� -<   $ creerPartieButton��$��Nouvelle Partie��$��
Old London)�$
��Bold"�
���-R��$��60(�
������ $	��360��$��0,5,0,0q��� -=   $ chargerPartie��$��Charger��$��
Old London)�$
��Bold"�
���-R��$��60(�$	��360��
������ $��0,10,0,0q��� ->   $ sauvegarderPartie��$��Sauvegarder��$��
Old London)�$
��Bold"�
���-R��$��60(�$	��360��
������ $��0,12,0,0q��� -?   $ quitter��$��Quitter��$��
Old London)�$
��Bold"�
���-R��$��60(�$	��360��
������ $��	0,100,0,0q�