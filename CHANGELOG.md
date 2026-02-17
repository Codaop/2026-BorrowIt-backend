# Changelog
Semua perubahan penting pada proyek **BorrowIt-backend** akan didokumentasikan di berkas ini. Format ini mengikuti standar [Keep a Changelog](https://keepachangelog.com/en/1.1.0/) dan [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0] - 2026-02-18
### Added
- **Core CRUD**: Implementasi lengkap Create, Read, Update, dan Delete untuk Riwayat Peminjaman.
- **Authentication**: Sistem login berbasis JWT Bearer dengan Role-based Authorization (Admin & Guest).
- **Security**: Implementasi fitur Soft Delete menggunakan field `IsDeleted` untuk integritas data.
- **Database**: Migrasi awal dan seeder data untuk tabel Ruangan dan Riwayat Peminjaman.
- **CORS**: Konfigurasi kebijakan lintas asal agar API dapat diakses oleh frontend React.

### Security
- Penggunaan `.env` untuk menyembunyikan kredensial database dan JWT Key.