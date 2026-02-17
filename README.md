# 2026-BorrowIt-backend

Aplikasi bagian backend untuk **Sistem Peminjaman Ruangan Kampus** yang dikembangkan menggunakan framework ASP.NET Core. Proyek ini merupakan bagian dari tugas **Project-Based Learning (PBL) 2026** di Politeknik Elektronika Negeri Surabaya.

## Deskripsi Proyek

Proyek ini bertujuan untuk menyediakan solusi digital bagi pengelolaan peminjaman ruangan yang terpusat dan efisien. Sistem ini memungkinkan pencatatan peminjaman, pemantauan status secara real-time, dan pendokumentasian riwayat penggunaan ruangan secara terstruktur.

## Fitur Utama

- **CRUD Riwayat Peminjaman**: Pengelolaan penuh data peminjaman (Create, Read, Update, Delete).
- **Soft Delete**: Menghapus data secara logis menggunakan field `IsDeleted` untuk menjaga integritas data.
- **JWT Stateless Authentication**: Pengamanan endpoint menggunakan JSON Web Token (JWT) Bearer.
- **Role-Based Authorization**: Pembedaan hak akses antara Admin (Pengelola) dan Guest (Peminjam).
- **Tracking Token**: Sistem pelacakan mandiri bagi pengguna Guest untuk mengelola riwayat mereka sendiri.
- **Admin Bypass**: Fitur khusus bagi Admin untuk mengelola data tanpa batasan token pelacakan.
- **Filtering & Pagination**: Pencarian data berdasarkan nama ruangan dan status dengan limitasi data yang efisien.

## Tech Stack

- **Framework**: ASP.NET Core Web API
- **Database**: MySQL
- **ORM**: Entity Framework Core
- **Auth**: JWT Authentication & BCrypt
- **CORS**: Terintegrasi untuk koneksi dengan Frontend React

## Prasyarat Sistem (Prerequisites)

Pastikan perangkat Anda (seperti Lenovo IdeaPad Slim 5 dengan Pop!_OS atau OS lainnya) telah memiliki:

* **.NET 10.0 SDK** atau versi terbaru.
* **MySQL Server** / **MariaDB** (menggunakan *Pomelo provider*).
* **Git** untuk manajemen repositori.
* **dotnet-ef tools** (untuk menjalankan migrasi database).

## Dependensi Paket (Dependencies)

Berikut adalah daftar paket NuGet yang digunakan dalam pengembangan proyek ini:

| Package | Versi | Kegunaan |
| :--- | :--- | :--- |
| **BCrypt.Net-Next** | Terbaru | Melakukan hashing password untuk keamanan data pengguna. |
| **Microsoft.EntityFrameworkCore** | Terbaru | [cite_start]Provider utama untuk interaksi dengan database melalui ORM[cite: 8, 231]. |
| **Pomelo.EntityFrameworkCore.MySql** | Terbaru | Driver khusus untuk menghubungkan Entity Framework Core dengan MySQL/MariaDB. |
| **Microsoft.AspNetCore.Authentication.JwtBearer** | Terbaru | Middleware untuk menangani autentikasi menggunakan token JWT. |
| **Microsoft.EntityFrameworkCore.Design** | Terbaru | Alat bantu untuk melakukan migrasi database (EF Core Tools). |

## Instalasi

Ikuti langkah berikut untuk menjalankan proyek di lingkungan lokal:

1. **Clone Repositori**:

   ```bash
   git clone https://github.com/Codaop/2026-BorrowIt-backend.git
   cd 2026-BorrowIt-backend
   ```

2. **Restore Dependencies**:

    ```bash
    dotnet restore
    ```

3. **Konfigurasi Environment & Keamanan**:

    Sesuai standar profesional, data sensitif dipisahkan dari kode utama.

    1. Buat file `.env` di root folder (gunakan `.env.example` sebagai referensi).
    2. Pastikan `.env` terdaftar di `.gitignore`.
    3. Isi variabel berikut:
    ``` ini
    # Koneksi Database MySQL
    ConnectionStrings__DefaultConnection="Server=localhost;Database=borrowit_db;User=root;Password=password_anda;"

    # Konfigurasi JWT (Stateless Authentication)
    Jwt__Key="Kunci_Rahasia_Minimal_32_Karakter_Untuk_Enkripsi"
    Jwt__Issuer="BorrowItBackend"
    Jwt__Audience="BorrowItFrontend"

    # Konfigurasi CORS (Izin akses untuk React Frontend)
    AllowedOrigins="http://localhost:3000"
    ```


4. **Setup Database & Migrasi**:

    Proyek ini menggunakan **Entity Framework Core** dengan fitur **Soft Delete**.

    Instal dependensi NuGet yang diperlukan:
    * `BCrypt.Net-Next` (untuk hashing password).
    * `Pomelo.EntityFrameworkCore.MySql` (driver database).
    * `Microsoft.AspNetCore.Authentication.JwtBearer` (keamanan).


5. Jalankan perintah migrasi untuk membuat skema database secara otomatis:
    ```bash
    dotnet ef database update

    ```


*Sistem akan otomatis mengaktifkan `IsDeleted = false` sebagai filter default di setiap query.*

## Konfigurasi CORS (Jembatan ke Frontend)

Untuk menghubungkan repositori ini dengan repositori **2026-BorrowIt-frontend** (React), backend telah dikonfigurasi pada `Program.cs` untuk mengizinkan:

* **Origin**: `http://localhost:3000`.
* **Methods**: `GET`, `POST`, `PUT`, `DELETE`.
* **Headers**: `Content-Type`, `Authorization`.

## Environment Variables

Pastikan kamu telah mengatur variabel berikut:

- `ConnectionStrings:DefaultConnection`: String koneksi database.
- `Jwt:Key`: Kunci rahasia untuk enkripsi token.
- `Jwt:Issuer`: Domain penerbit token.
- `Jwt:Audience`: Domain target audiens.

## Struktur API Endpoints
Berikut adalah beberapa contoh format yang digunakan pada path controller:

| Method | Endpoint                   | Akses       | Deskripsi                          |
| ------ | -------------------------- | ----------- | ---------------------------------- |
| GET    | `/api/Ruangans`            | Anonymous   | Melihat daftar dan detail ruangan  |
| POST   | `/api/Auth/login`          | Anonymous   | Autentikasi Admin                  |
| GET    | `/api/RiwayatPinjams`      | Admin       | Melihat seluruh riwayat peminjaman |
| PUT    | `/api/RiwayatPinjams/{id}` | Guest/Admin | Memperbarui data/status peminjaman |
| DELETE | `/api/RiwayatPinjams/{id}` | Guest/Admin | Menghapus riwayat (Soft Delete)    |

## Lisensi

Proyek ini dilisensikan di bawah **MIT License**.

## Penulis

**Muhammad Syauqy Arrayyan** - Mahasiswa S.Tr. Teknik Informatika, PENS 2024.