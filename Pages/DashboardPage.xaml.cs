using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ADCoins.Pages
{
    public partial class DashboardPage : Page
    {
        public DashboardPage()
        {
            InitializeComponent();
        }


        // =========================================
        // CALCULAR
        // =========================================

        private void CalcularButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            try
            {
                decimal valor250TC =
                    LerReais(Valor250TCInput.Text);

                decimal valorTCGold =
                    LerGold(ValorTCGoldInput.Text);

                decimal valorFarmado =
                    LerGold(ValorFarmadoInput.Text);


                // =========================================
                // QUANTIDADE DE TC
                // =========================================

                decimal quantidadeTC = 0;

                if (valorTCGold > 0)
                {
                    quantidadeTC =
                        valorFarmado / valorTCGold;
                }


                // =========================================
                // VALOR DO FARM EM REAIS
                // =========================================

                decimal valorFarmadoReais = 0;

                if (valor250TC > 0)
                {
                    valorFarmadoReais =
                        (quantidadeTC / 250m) * valor250TC;
                }


                // =========================================
                // ATUALIZA OS CARDS
                // =========================================

                Valor250TCText.Text =
                    $"R$ {valor250TC:N2}";

                Valor1TCText.Text =
                    $"{valorTCGold:N0} GOLD";

                ValorFarmadoText.Text =
                    $"{valorFarmado:N0} GOLD";


                // =========================================
                // RESULTADO
                // =========================================

                ResultadoTCText.Text =
                    $"{quantidadeTC:N2} TC";

                ResultadoReaisText.Text =
                    $"R$ {valorFarmadoReais:N2}";
            }
            catch
            {
                MessageBox.Show(
                    "Não consegui interpretar um dos valores informados.\n\n" +
                    "Confira os campos e tente novamente.",
                    "Valor inválido",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }


        // =========================================
        // COPIAR RESULTADO
        // =========================================

        private void CopiarResultadoButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            string resultado =
                "ADCoins - Resultado da Conversão\n\n" +
                $"Valor de 250 TC: {Valor250TCText.Text}\n" +
                $"Valor de 1 TC: {Valor1TCText.Text}\n" +
                $"Valor Farmado: {ValorFarmadoText.Text}\n\n" +
                $"TC Obtidas: {ResultadoTCText.Text}\n" +
                $"Valor do Farm em R$: {ResultadoReaisText.Text}";

            Clipboard.SetText(resultado);

            MessageBox.Show(
                "Resultado copiado para a área de transferência!",
                "ADCoins",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }


        // =========================================
        // LEITURA DE REAIS
        // =========================================

        private decimal LerReais(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return 0;

            texto = texto.Trim();

            texto = texto
                .Replace("R$", "")
                .Trim();

            // Ponto e vírgula funcionam como
            // separadores de centavos.

            texto = texto.Replace(",", ".");

            if (!decimal.TryParse(
                    texto,
                    NumberStyles.AllowDecimalPoint,
                    CultureInfo.InvariantCulture,
                    out decimal valor))
            {
                throw new Exception();
            }

            return valor;
        }


        // =========================================
        // LEITURA DE GOLD
        // =========================================

        private decimal LerGold(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return 0;

            texto = texto
                .Trim()
                .ToLower();

            texto = texto.Replace(" ", "");


            // =========================================
            // KKK
            // =========================================

            if (texto.EndsWith("kkk"))
            {
                string numero =
                    texto[..^3].Replace(",", ".");

                if (!decimal.TryParse(
                        numero,
                        NumberStyles.AllowDecimalPoint,
                        CultureInfo.InvariantCulture,
                        out decimal valor))
                {
                    throw new Exception();
                }

                return valor * 1_000_000_000m;
            }


            // =========================================
            // KK
            // =========================================

            if (texto.EndsWith("kk"))
            {
                string numero =
                    texto[..^2].Replace(",", ".");

                if (!decimal.TryParse(
                        numero,
                        NumberStyles.AllowDecimalPoint,
                        CultureInfo.InvariantCulture,
                        out decimal valor))
                {
                    throw new Exception();
                }

                return valor * 1_000_000m;
            }


            // =========================================
            // K
            // =========================================

            if (texto.EndsWith("k"))
            {
                string numero =
                    texto[..^1].Replace(",", ".");

                if (!decimal.TryParse(
                        numero,
                        NumberStyles.AllowDecimalPoint,
                        CultureInfo.InvariantCulture,
                        out decimal valor))
                {
                    throw new Exception();
                }

                return valor * 1_000m;
            }


            // =========================================
            // GOLD SEM K
            // =========================================

            string somenteNumeros =
                new string(
                    texto.Where(char.IsDigit).ToArray());

            if (string.IsNullOrWhiteSpace(somenteNumeros))
                throw new Exception();

            if (!decimal.TryParse(
                    somenteNumeros,
                    NumberStyles.None,
                    CultureInfo.InvariantCulture,
                    out decimal gold))
            {
                throw new Exception();
            }

            return gold;
        }
    }
}