using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ADCoins.Pages
{
    public partial class ImbuementsPage : Page
    {
        public ImbuementsPage()
        {
            InitializeComponent();
        }


        // =========================================
        // CLIQUE NO EQUIPAMENTO
        // =========================================

        private void EquipmentButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (sender is not Button button)
                return;

            string equipamento =
                button.Tag?.ToString() ?? "";

            MostrarEquipamento(equipamento);
        }


        // =========================================
        // MOSTRAR EQUIPAMENTO
        // =========================================

        private void MostrarEquipamento(string equipamento)
        {
            SlotsPanel.Children.Clear();

            int quantidadeSlots =
                ObterQuantidadeSlots(equipamento);


            SelectedEquipmentText.Text =
                equipamento;


            // =========================================
            // SEM SLOTS
            // =========================================

            if (quantidadeSlots == 0)
            {
                SelectedEquipmentDescription.Text =
                    "Este equipamento não possui slots de imbuement.";

                TextBlock semSlot =
                    new TextBlock
                    {
                        Text = "Sem slots disponíveis",

                        Foreground =
                            new SolidColorBrush(
                                Color.FromRgb(136, 136, 136)),

                        FontSize = 16,

                        Margin =
                            new Thickness(0, 10, 0, 0)
                    };

                SlotsPanel.Children.Add(semSlot);

                return;
            }


            // =========================================
            // DESCRIÇÃO
            // =========================================

            SelectedEquipmentDescription.Text =
                $"{quantidadeSlots} slot(s) disponível(is).";


            // =========================================
            // CRIA OS SLOTS
            // =========================================

            for (int i = 1; i <= quantidadeSlots; i++)
            {
                Border slot =
                    CriarSlot(
                        equipamento,
                        i);

                SlotsPanel.Children.Add(slot);
            }
        }


        // =========================================
        // QUANTIDADE DE SLOTS
        // =========================================

        private int ObterQuantidadeSlots(
            string equipamento)
        {
            return equipamento switch
            {
                "Amulet" => 1,
                "Helmet" => 2,
                "Backpack" => 1,
                "Weapon" => 3,
                "Armor" => 3,
                "Legs" => 0,
                "Shield" => 1,
                "Ring" => 1,
                "Boots" => 1,
                "Trinket" => 1,

                _ => 0
            };
        }


        // =========================================
        // OPÇÕES DE IMBUEMENT
        // =========================================

        private List<string> ObterOpcoes(
            string equipamento,
            int numeroSlot)
        {
            switch (equipamento)
            {
                // =====================================
                // HELMET
                // =====================================

                case "Helmet":

                    if (numeroSlot == 1)
                    {
                        return new List<string>
                        {
                            "Mana Leech"
                        };
                    }

                    if (numeroSlot == 2)
                    {
                        return new List<string>
                        {
                            "Magic Level",
                            "Skill"
                        };
                    }

                    break;


                // =====================================
                // WEAPON
                // =====================================

                case "Weapon":

                    if (numeroSlot == 1)
                    {
                        return new List<string>
                        {
                            "Mana Leech"
                        };
                    }

                    if (numeroSlot == 2)
                    {
                        return new List<string>
                        {
                            "Life Leech"
                        };
                    }

                    if (numeroSlot == 3)
                    {
                        return new List<string>
                        {
                            "Critical"
                        };
                    }

                    break;


                // =====================================
                // ARMOR
                // =====================================

                case "Armor":

                    if (numeroSlot == 1)
                    {
                        return new List<string>
                        {
                            "Life Leech"
                        };
                    }

                    if (numeroSlot == 2 ||
                        numeroSlot == 3)
                    {
                        return new List<string>
                        {
                            "Fire Protection",
                            "Ice Protection",
                            "Energy Protection",
                            "Death Protection",
                            "Earth Protection",
                            "Holy Protection"
                        };
                    }

                    break;


                // =====================================
                // SHIELD
                // =====================================

                case "Shield":

                    return new List<string>
                    {
                        "Fire Protection",
                        "Ice Protection",
                        "Energy Protection",
                        "Death Protection",
                        "Earth Protection",
                        "Holy Protection"
                    };


                // =====================================
                // BOOTS
                // =====================================

                case "Boots":

                    return new List<string>
                    {
                        "Paralysis Protection",
                        "Speed"
                    };


                // =====================================
                // BACKPACK
                // =====================================

                case "Backpack":

                    return new List<string>
                    {
                        "Capacity"
                    };


                // =====================================
                // RING
                // =====================================

                case "Ring":

                    return new List<string>
                    {
                        "Selecionar posteriormente"
                    };


                // =====================================
                // AMULET
                // =====================================

                case "Amulet":

                    return new List<string>
                    {
                        "Selecionar posteriormente"
                    };


                // =====================================
                // TRINKET
                // =====================================

                case "Trinket":

                    return new List<string>
                    {
                        "Selecionar posteriormente"
                    };
            }


            return new List<string>();
        }


        // =========================================
        // CRIAR SLOT
        // =========================================

        private Border CriarSlot(
            string equipamento,
            int numeroSlot)
        {
            Border border =
                new Border
                {
                    Background =
                        new SolidColorBrush(
                            Color.FromRgb(37, 37, 37)),

                    BorderBrush =
                        new SolidColorBrush(
                            Color.FromRgb(58, 58, 58)),

                    BorderThickness =
                        new Thickness(1),

                    CornerRadius =
                        new CornerRadius(8),

                    Padding =
                        new Thickness(15),

                    Margin =
                        new Thickness(0, 5, 0, 5)
                };


            StackPanel painel =
                new StackPanel();


            // =========================================
            // TÍTULO
            // =========================================

            TextBlock titulo =
                new TextBlock
                {
                    Text =
                        $"Slot {numeroSlot}",

                    Foreground =
                        new SolidColorBrush(
                            Colors.White),

                    FontSize = 16,

                    FontWeight =
                        FontWeights.Bold
                };


            painel.Children.Add(titulo);


            // =========================================
            // COMBOBOX
            // =========================================

            ComboBox comboBox =
                new ComboBox
                {
                    Height = 38,

                    Margin =
                        new Thickness(0, 10, 0, 0),

                    Background =
                        new SolidColorBrush(
                            Color.FromRgb(45, 45, 45)),

                    Foreground =
                        new SolidColorBrush(
                            Colors.White),

                    BorderBrush =
                        new SolidColorBrush(
                            Color.FromRgb(70, 70, 70))
                };


            comboBox.Items.Add(
                "Selecione o imbuement");


            List<string> opcoes =
                ObterOpcoes(
                    equipamento,
                    numeroSlot);


            foreach (string opcao in opcoes)
            {
                comboBox.Items.Add(opcao);
            }


            comboBox.SelectedIndex = 0;


            painel.Children.Add(comboBox);


            // =========================================
            // NÍVEL
            // =========================================

            TextBlock nivelLabel =
                new TextBlock
                {
                    Text = "Nível do Imbuement",

                    Foreground =
                        new SolidColorBrush(
                            Color.FromRgb(136, 136, 136)),

                    FontSize = 13,

                    Margin =
                        new Thickness(0, 12, 0, 5)
                };


            painel.Children.Add(nivelLabel);


            ComboBox nivelComboBox =
                new ComboBox
                {
                    Height = 35
                };


            nivelComboBox.Items.Add("Basic");
            nivelComboBox.Items.Add("Intricate");
            nivelComboBox.Items.Add("Powerful");

            nivelComboBox.SelectedIndex = 0;


            painel.Children.Add(nivelComboBox);


            border.Child = painel;


            return border;
        }
    }
}