using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MusicCollectionApp
{
    public partial class Form1 : Form
    {
        // Коллекция для хранения музыкальных треков
        private List<MusicTrack> musicTracks = new List<MusicTrack>();
        private string dataFilePath = "Music.txt";

        public Form1()
        {
            InitializeComponent();
            InitializeListView();
            LoadMusicTracks();
        }

        /// <summary>
        /// Инициализация ListView
        /// </summary>
        private void InitializeListView()
        {
            tracksListView.View = View.Details;
            tracksListView.FullRowSelect = true;
            tracksListView.GridLines = true;

            // Добавление колонок
            tracksListView.Columns.Add("Название трека", 200);
            tracksListView.Columns.Add("Исполнитель", 150);
            tracksListView.Columns.Add("Альбом", 150);
            tracksListView.Columns.Add("Год выпуска", 80, HorizontalAlignment.Center);
        }

        /// <summary>
        /// Загрузка данных из файла при запуске
        /// </summary>
        private void LoadMusicTracks()
        {
            if (!File.Exists(dataFilePath))
                return;

            try
            {
                string[] lines = File.ReadAllLines(dataFilePath, Encoding.UTF8);

                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 4)
                    {
                        int year;
                        if (int.TryParse(parts[3].Trim(), out year))
                        {
                            MusicTrack track = new MusicTrack(
                                parts[0].Trim(),
                                parts[1].Trim(),
                                parts[2].Trim(),
                                year
                            );

                            musicTracks.Add(track);
                        }
                    }
                }

                UpdateTrackListView();
                MessageBox.Show($"Загружено {musicTracks.Count} треков", "Информация",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обновление отображения ListView
        /// </summary>
        private void UpdateTrackListView()
        {
            tracksListView.Items.Clear();

            foreach (MusicTrack track in musicTracks)
            {
                ListViewItem item = new ListViewItem(track.TrackTitle);
                item.SubItems.Add(track.Artist);
                item.SubItems.Add(track.Album);
                item.SubItems.Add(track.ReleaseYear.ToString());

                tracksListView.Items.Add(item);
            }

            // Отображение количества треков
            Text = $"Коллекция музыки - {musicTracks.Count} треков";
        }

        /// <summary>
        /// Обработчик кнопки "Добавить трек"
        /// </summary>
       

        /// <summary>
        /// Обработчик кнопки "Редактировать трек"
        /// </summary>
        private void editTrackButton_Click(object sender, EventArgs e)
        {
            if (tracksListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите трек для редактирования",
                              "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int index = tracksListView.SelectedItems[0].Index;

            // Создаем копию трека для редактирования
            MusicTrack selectedTrack = musicTracks[index];
            MusicTrack trackToEdit = new MusicTrack(
                selectedTrack.TrackTitle,
                selectedTrack.Artist,
                selectedTrack.Album,
                selectedTrack.ReleaseYear
            );

            EditTrackForm editForm = new EditTrackForm();
            editForm.Track = trackToEdit;

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                if (!editForm.Track.IsValid())
                {
                    MessageBox.Show("Некорректные данные трека", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Обновляем трек в коллекции
                musicTracks[index] = editForm.Track;
                UpdateTrackListView();

                MessageBox.Show("Данные трека обновлены", "Успех",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Обработчик кнопки "Сохранить коллекцию"
        /// </summary>
       

        private void addTrackButton_Click_1(object sender, EventArgs e)
        {
            EditTrackForm editForm = new EditTrackForm();
            editForm.Track = new MusicTrack(); // Создаем новый трек

            if (editForm.ShowDialog() != DialogResult.OK)
                return;

            // Проверка валидности данных
            if (!editForm.Track.IsValid())
            {
                MessageBox.Show("Некорректные данные трека", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            musicTracks.Add(editForm.Track);
            UpdateTrackListView();

            MessageBox.Show("Трек добавлен в коллекцию", "Успех",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void saveButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(dataFilePath, false, Encoding.UTF8))
                {
                    foreach (MusicTrack track in musicTracks)
                    {
                        writer.WriteLine($"{track.TrackTitle}|{track.Artist}|{track.Album}|{track.ReleaseYear}");
                    }
                }

                MessageBox.Show($"Коллекция сохранена в файл {dataFilePath}\n" +
                              $"Сохранено треков: {musicTracks.Count}",
                              "Успешное сохранение",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tracksListView_DoubleClick_1(object sender, EventArgs e)
        {
            editTrackButton_Click(sender, e);
        }
    }
}