using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicCollectionApp
{
    public partial class EditTrackForm : Form
    {
        // Свойство для работы с музыкальным треком
        public MusicTrack Track { get; set; }

        public EditTrackForm()
        {
            InitializeComponent();
        }

        private void EditTrackForm_Load(object sender, EventArgs e)
        {
            yearNumericUpDown.Maximum = DateTime.Now.Year + 1;

            if (Track != null)
            {
                titleTextBox.Text = Track.TrackTitle;
                artistTextBox.Text = Track.Artist;
                albumTextBox.Text = Track.Album;
                yearNumericUpDown.Value = Track.ReleaseYear;
            }
            else
            {
                yearNumericUpDown.Value = DateTime.Now.Year;
            }

            titleTextBox.Focus();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            // Сохранение данных
            if (Track == null)
                Track = new MusicTrack();

            Track.TrackTitle = titleTextBox.Text.Trim();
            Track.Artist = artistTextBox.Text.Trim();
            Track.Album = albumTextBox.Text.Trim();
            Track.ReleaseYear = (int)yearNumericUpDown.Value;

            // Установка результата диалога
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Проверка корректности введенных данных
        /// </summary>
        /// <returns>true если данные корректны</returns>
        private bool ValidateForm()
        {
            // Проверка названия трека
            if (string.IsNullOrWhiteSpace(titleTextBox.Text))
            {
                MessageBox.Show("Введите название композиции", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                titleTextBox.Focus();
                return false;
            }

            // Проверка исполнителя
            if (string.IsNullOrWhiteSpace(artistTextBox.Text))
            {
                MessageBox.Show("Введите исполнителя", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                artistTextBox.Focus();
                return false;
            }

            // Проверка года выпуска
            int year = (int)yearNumericUpDown.Value;
            if (year < 1900 || year > DateTime.Now.Year + 1)
            {
                MessageBox.Show($"Год выпуска должен быть в диапазоне 1900-{DateTime.Now.Year + 1}",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                yearNumericUpDown.Focus();
                return false;
            }

            return true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void EditTrackForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                saveButton_Click(sender, e);
                e.Handled = true;
            }
            // Отмена по Escape
            else if (e.KeyCode == Keys.Escape)
            {
                cancelButton_Click(sender, e);
            }
        }
    }
}


        /// <summary>
        /// Загрузка формы
        /// </summary>
