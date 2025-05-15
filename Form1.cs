using System;
using System.IO;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

namespace TI_4
{
    public partial class Form1 : Form
    {
        private string fileContent = "";
        private string signedFilePath = "";
        private BigInteger r = BigInteger.Zero;
        private BigInteger s = BigInteger.Zero;
        private const int DefaultH0 = 100; // Константа вместо параметра по умолчанию
        private string filePath = ""; // Для хранения пути к текущему файлу

        public Form1()
        {
            InitializeComponent();
        }

        // Хеш-функция по методичке (без параметра по умолчанию)
        private BigInteger CalculateHash(string message, BigInteger p, BigInteger q)
        {
            // Вычисляем n = p*q (аналог константы 323 в Swift-коде)
            BigInteger n = p * q;
            BigInteger hash = DefaultH0; // Начальное значение H0 = 100

            foreach (char c in message)
            {
                BigInteger charValue = (int)c; // Получаем ASCII-код символа
                hash = BigInteger.ModPow(hash + charValue, 2, n);
            }

            return hash % q; // Финальное взятие по модулю q
        }

        private int CharToNumber(char c)
        {
            // A=1, B=2, ..., Z=26 (только английские)
            if (c >= 'A' && c <= 'Z') return c - 'A' + 1;
            if (c >= 'a' && c <= 'a') return c - 'a' + 1;
            return 0; // Для остальных
        }

        // Быстрое возведение в степень по модулю
        private BigInteger ModExp(BigInteger number, BigInteger exponent, BigInteger modulus)
        {
            return BigInteger.ModPow(number, exponent, modulus);
        }

        // Обратный элемент по малой теореме Ферма
        private BigInteger ModInverse(BigInteger a, BigInteger q)
        {
            return ModExp(a, q - 2, q); // Малая теорема Ферма
        }

        // Проверка на простоту (упрощенная)
        private bool IsPrime(BigInteger number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (BigInteger)Math.Floor(Math.Exp(BigInteger.Log(number) / 2));

            for (BigInteger i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    fileContent = File.ReadAllText(filePath, Encoding.UTF8);
                    textBoxFileContent.Text = fileContent;
                    MessageBox.Show("Файл успешно загружен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void GenerateSign_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем параметры
                BigInteger q = BigInteger.Parse(textBoxQ.Text);
                BigInteger p = BigInteger.Parse(textBoxP.Text);
                BigInteger n = p * q;

                BigInteger h = BigInteger.Parse(TextBoxH.Text);
                BigInteger x = BigInteger.Parse(textBoxX.Text);
                BigInteger k = BigInteger.Parse(textBoxK.Text);

                // Проверки параметров
                if (!IsPrime(q)) throw new ArgumentException("q должно быть простым числом");
                if (!IsPrime(p)) throw new ArgumentException("p должно быть простым числом");
                if ((p - 1) % q != 0) throw new ArgumentException("q должно быть делителем (p-1)");
                if (x <= 0 || x >= q) throw new ArgumentException("x должно быть в интервале (0, q)");
                if (k <= 0 || k >= q) throw new ArgumentException("k должно быть в интервале (0, q)");

                // Вычисляем g
                BigInteger g = ModExp(h, (p - 1) / q, p);
                if (g <= 1) throw new ArgumentException("g должно быть больше 1");

                // Для пустого файла fileContent будет "", но хеш все равно вычислится
                BigInteger hash = CalculateHash(fileContent ?? "", p, q);
                TextBoxForHash.Text = hash.ToString();

                // Вычисляем подпись
                do
                {
                    r = ModExp(g, k, p) % q;
                    if (r == 0)
                    {
                        MessageBox.Show("r = 0, введите другое значение k", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxK.Text = "";
                        return;
                    }

                    BigInteger kInv = ModInverse(k, q);
                    s = (kInv * (hash + x * r)) % q;

                    if (s == 0)
                    {
                        MessageBox.Show("s = 0, введите другое значение k", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxK.Text = "";
                        return;
                    }
                } while (r == 0 || s == 0);

                textBoxForSign.Text = $"r = {r}\ns = {s}";
                MessageBox.Show("Подпись успешно сгенерирована", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveSignFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (r == 0 || s == 0)
                {
                    throw new ArgumentException("Сначала сгенерируйте подпись");
                }

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.FileName = string.IsNullOrEmpty(filePath)
                        ? "signed_file.txt"
                        : Path.GetFileNameWithoutExtension(filePath) + "_signed" + Path.GetExtension(filePath);

                    saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        signedFilePath = saveFileDialog.FileName;
                        File.WriteAllText(signedFilePath, $"{fileContent}\n---SIGNATURE---\n{r}\n{s}", Encoding.UTF8);
                        textBoxFileContent.Text = fileContent; // Обновляем содержимое
                        MessageBox.Show("Подписанный файл успешно сохранен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SignatureFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    signedFilePath = openFileDialog.FileName;
                    string content = File.ReadAllText(signedFilePath, Encoding.UTF8);
                    textBoxFileContent.Text = content; // Показываем содержимое файла
                    MessageBox.Show("Подписанный файл успешно загружен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void CheckSign_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем параметры
                BigInteger q = BigInteger.Parse(textBoxQ.Text);
                BigInteger p = BigInteger.Parse(textBoxP.Text);
                BigInteger h = BigInteger.Parse(TextBoxH.Text);
                BigInteger x = BigInteger.Parse(textBoxX.Text);

                // Проверки параметров
                if (!IsPrime(q)) throw new ArgumentException("q должно быть простым числом");
                if (!IsPrime(p)) throw new ArgumentException("p должно быть простым числом");
                if ((p - 1) % q != 0) throw new ArgumentException("q должно быть делителем (p-1)");

                // Вычисляем g
                BigInteger g = ModExp(h, (p - 1) / q, p);
                if (g <= 1) throw new ArgumentException("g должно быть больше 1");

                // Вычисляем открытый ключ y
                BigInteger y = ModExp(g, x, p);

                if (string.IsNullOrEmpty(signedFilePath) || !File.Exists(signedFilePath))
                {
                    throw new ArgumentException("Сначала загрузите подписанный файл");
                }

                string[] fileLines = File.ReadAllLines(signedFilePath, Encoding.UTF8);

                // Ищем индекс строки с разделителем подписи
                int signatureIndex = -1;
                for (int i = 0; i < fileLines.Length; i++)
                {
                    if (fileLines[i] == "---SIGNATURE---")
                    {
                        signatureIndex = i;
                        break;
                    }
                }

                if (signatureIndex == -1 || signatureIndex >= fileLines.Length - 2)
                {
                    throw new ArgumentException("Файл не содержит подпись в правильном формате");
                }

                // Извлекаем сообщение и подпись
                string message = string.Join("\n", fileLines, 0, signatureIndex);
                BigInteger fileR = BigInteger.Parse(fileLines[signatureIndex + 1]);
                BigInteger fileS = BigInteger.Parse(fileLines[signatureIndex + 2]);

                // Вычисляем хеш сообщения (работает и для пустой строки)
                BigInteger hash = CalculateHash(message, p, q);

                // Проверяем подпись
                BigInteger w = ModInverse(fileS, q);
                BigInteger u1 = (hash * w) % q;
                BigInteger u2 = (fileR * w) % q;
                BigInteger v = (ModExp(g, u1, p) * ModExp(y, u2, p)) % p % q;

                // Выводим результаты
                string result = v == fileR ? "Подпись верна" : "Подпись неверна";
                string details = $"Вычисленные значения:\nw = {w}\nu1 = {u1}\nu2 = {u2}\nv = {v}\nr из файла = {fileR}";

                MessageBox.Show($"{result}\n\n{details}", "Результат проверки", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Пустая реализация
        }
    }
}