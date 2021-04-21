PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "AspNetRoles" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_AspNetRoles" PRIMARY KEY,
    "Name" TEXT NULL,
    "NormalizedName" TEXT NULL,
    "ConcurrencyStamp" TEXT NULL
);
INSERT INTO AspNetRoles VALUES('3c6ced2c-cab9-4d39-8e88-82784a334717','customer','CUSTOMER','a8ea2ef8-8869-4876-8c44-7d95d3cc9c22');
INSERT INTO AspNetRoles VALUES('24ba40a8-1b4a-48ad-8162-73c52bfadd1b','Seller','SELLER','5c4aaa28-e956-4b95-819a-bafdc094b63a');
CREATE TABLE IF NOT EXISTS "AspNetUsers" (

    "Id" TEXT NOT NULL CONSTRAINT "PK_AspNetUsers" PRIMARY KEY,

    "UserName" TEXT NULL,

    "NormalizedUserName" TEXT NULL,

    "Email" TEXT NULL,

    "NormalizedEmail" TEXT NULL,

    "EmailConfirmed" INTEGER NOT NULL,

    "PasswordHash" TEXT NULL,

    "SecurityStamp" TEXT NULL,

    "ConcurrencyStamp" TEXT NULL,

    "PhoneNumber" TEXT NULL,

    "PhoneNumberConfirmed" INTEGER NOT NULL,

    "TwoFactorEnabled" INTEGER NOT NULL,

    "LockoutEnd" TEXT NULL,

    "LockoutEnabled" INTEGER NOT NULL,

    "AccessFailedCount" INTEGER NOT NULL

);
INSERT INTO AspNetUsers VALUES('df881f98-636e-4389-91a7-cd20d2e564d1','0931421321','0931421321','trong@gmail.com','TRONG@GMAIL.COM',0,'AQAAAAEAACcQAAAAEHqQl7TM1M7rScWLjGelef6i4SBgb2BL2/400oCGy8FWsS48JhfvMl4gW+dgVecgIQ==','LA5OJAHEGHXDPM7H3LXMDQVHDXNNQ5XK','bb107a54-b97a-4623-9e07-decfcd110de6','09123456',1,0,NULL,1,0);
INSERT INTO AspNetUsers VALUES('3ab9fa28-b104-448c-a7b2-ac55ad86f83c','0931421322','0931421322','trong@gmail.com','TRONG@GMAIL.COM',0,'AQAAAAEAACcQAAAAEB5FfJylH2wjOjvh1Jp2xqrUpMm6Ix07UOdk6Tc0o70tPlfZW6v5FaJ7FDTtV53jSQ==','T5RNIQLYKG6GMV7RCXDCI5H55BPQZHJW','4a807684-12cc-4762-acd2-f1a80aaf8477','09123456',1,0,NULL,1,0);
INSERT INTO AspNetUsers VALUES('a9ea49aa-444f-415e-a2c3-35a521a71f5f','0858267296','0858267296','tranphanthanhlong18@gmail.com','TRANPHANTHANHLONG18@GMAIL.COM',0,'AQAAAAEAACcQAAAAEGuCgJmKlfsBgHybMMl3Y7oeVIA/duMckXuLRl8h1hNOmXOC6NjUqqpEkh3qxT/jEA==','T2QI6SXA77XQIUIFVAYY5V7OBFCHFACN','d25ed00c-426d-4a76-9bf7-bc01b58d62c1','Long Tran',0,0,NULL,1,0);
CREATE TABLE IF NOT EXISTS "brands" (

    "id" INTEGER NOT NULL CONSTRAINT "PK_brands" PRIMARY KEY AUTOINCREMENT,

    "name" TEXT NULL

);
INSERT INTO brands VALUES(1,'number1');
INSERT INTO brands VALUES(2,'number2');
INSERT INTO brands VALUES(3,'number3');
CREATE TABLE IF NOT EXISTS "category" (

    "id" INTEGER NOT NULL CONSTRAINT "PK_category" PRIMARY KEY AUTOINCREMENT,

    "name" TEXT NULL

);
INSERT INTO category VALUES(1,'hello long tran');
CREATE TABLE IF NOT EXISTS "customers" (

    "id" INTEGER NOT NULL CONSTRAINT "PK_customers" PRIMARY KEY AUTOINCREMENT,

    "name" TEXT NULL,

    "email" TEXT NULL,

    "phoneNumber" TEXT NULL,

    "password" TEXT NULL,

    "accessToken" TEXT NULL,

    "accesExpire" TEXT NOT NULL,

    "refreshToken" TEXT NULL

, "gender" TEXT default 'male');
INSERT INTO customers VALUES(1,'09123456','trong@gmail.com','0931421321','AQAAAAEAACcQAAAAEHqQl7TM1M7rScWLjGelef6i4SBgb2BL2/400oCGy8FWsS48JhfvMl4gW+dgVecgIQ==','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMDkzMTQyMTMyMSIsImp0aSI6IjIwNmJhNTgyLTliM2YtNDM0Ny05M2EwLWZjNDUwOTBmYjViMSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6ImN1c3RvbWVyIiwiZXhwIjoxNjE5NjkwMjQwLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAifQ.i1xqzdddKEqihXMNUwPpmova4STETwPomKJCT6keWtM','2021-04-29 09:57:20','0a26de9e-87a0-4b97-b39c-4aef23b820c8','male');
INSERT INTO customers VALUES(2,'09123456','trong@gmail.com','0931421321','AQAAAAEAACcQAAAAEHqQl7TM1M7rScWLjGelef6i4SBgb2BL2/400oCGy8FWsS48JhfvMl4gW+dgVecgIQ==','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMDkzMTQyMTMyMSIsImp0aSI6IjEwNDA4OTFiLTViYzctNDc1Ny04YjU1LTM5ZjVhZDM1MjY2NyIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6ImN1c3RvbWVyIiwiZXhwIjoxNjE5NjkyMjUwLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAifQ.1cSfNAlyR-E-AkC69DpQkRGCgFPK2srw9Dha2KVt150','2021-04-29 10:30:50','bcbb0ca0-3d68-47ac-b6e1-92bdf638b768','male');
INSERT INTO customers VALUES(3,'09123456','trong@gmail.com','0931421322','AQAAAAEAACcQAAAAEB5FfJylH2wjOjvh1Jp2xqrUpMm6Ix07UOdk6Tc0o70tPlfZW6v5FaJ7FDTtV53jSQ==','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMDkzMTQyMTMyMiIsImp0aSI6ImJhNjNiOTM2LTNjY2QtNGUwNi04NzJlLTUyZmZlMjVlYzFlMiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6ImN1c3RvbWVyIiwiZXhwIjoxNjE5Njk0NzAzLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAifQ.OZnSsbEu0GXtg9dD7pncBDX3ODNxLcdKVr5a5wTdslg','2021-04-29 11:11:43','cebb2613-f833-40a6-b810-d084328066d5','male');
INSERT INTO customers VALUES(4,'09123456','trong@gmail.com','0931421322','AQAAAAEAACcQAAAAEB5FfJylH2wjOjvh1Jp2xqrUpMm6Ix07UOdk6Tc0o70tPlfZW6v5FaJ7FDTtV53jSQ==','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMDkzMTQyMTMyMiIsImp0aSI6ImUzZDZkYjc2LWZlNGMtNGY5ZC1hODM3LTc5ZWQxMWY3OTY1OCIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6ImN1c3RvbWVyIiwiZXhwIjoxNjE5NzA1MTExLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAifQ.UQw4G8y50YWZkIJ0RQ_AhkrW8cHcAmdsXxxT9cZM3LA','2021-04-29 14:05:11','224fd4bc-bad3-4316-8818-be0f2cfcbb86','male');
INSERT INTO customers VALUES(5,'09123456','trong@gmail.com','0931421322','AQAAAAEAACcQAAAAEB5FfJylH2wjOjvh1Jp2xqrUpMm6Ix07UOdk6Tc0o70tPlfZW6v5FaJ7FDTtV53jSQ==','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMDkzMTQyMTMyMiIsImp0aSI6IjQwNTFkMWFlLWUwMTQtNDdhZC1hZjIwLTQ3MDc3MDc3Y2MyYiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6ImN1c3RvbWVyIiwiZXhwIjoxNjE5NzA1MzQ1LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAifQ.0i2SF0KMwNt_-MVcVPn9yKIpg4RUkkGfbk5LuS24umM','2021-04-29 14:09:05','c8123fcc-1473-4381-a010-4bb6f6c66f68','male');
INSERT INTO customers VALUES(6,'09123456','trong@gmail.com','0931421322','AQAAAAEAACcQAAAAEB5FfJylH2wjOjvh1Jp2xqrUpMm6Ix07UOdk6Tc0o70tPlfZW6v5FaJ7FDTtV53jSQ==','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMDkzMTQyMTMyMiIsImp0aSI6ImJmYzkzOTQ2LWNlYzAtNGY5Ni1iOWE1LTI1YjE5ZGI2YmQ4ZCIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6ImN1c3RvbWVyIiwiZXhwIjoxNjE5NzA1NTc3LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAifQ.wWi1IJZFXvCkhbqdQ2-zz_o1UMwKGyi-i3xjctrskAg','2021-04-29 14:12:57','69dbb7b3-6487-484e-996d-20404c5ad781','male');
INSERT INTO customers VALUES(7,'09123456','trong@gmail.com','0931421322','AQAAAAEAACcQAAAAEB5FfJylH2wjOjvh1Jp2xqrUpMm6Ix07UOdk6Tc0o70tPlfZW6v5FaJ7FDTtV53jSQ==','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMDkzMTQyMTMyMiIsImp0aSI6IjI2YmM4NjU1LTIwMjgtNDk4Zi04ZmMzLTQyOGUxOWRiODNkYiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6ImN1c3RvbWVyIiwiZXhwIjoxNjE5NzA1ODE1LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAifQ.vEB17Pcj4EE3HGRXbmVkImpVYmFjPIMGw57kra-Mlaw','2021-04-29 14:16:55','0dae9265-4321-4386-bbcd-dc895686c14c','male');
INSERT INTO customers VALUES(8,'09123456','trong@gmail.com','0931421322','AQAAAAEAACcQAAAAEB5FfJylH2wjOjvh1Jp2xqrUpMm6Ix07UOdk6Tc0o70tPlfZW6v5FaJ7FDTtV53jSQ==','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIwOTMxNDIxMzIyIiwianRpIjoiZTg4ZmIwYzQtYzUyOC00ZDM1LThlNjktNGI1YThmMjI4MzVlIiwicm9sZSI6ImN1c3RvbWVyIiwiZXhwIjoxNjE5NzA3MDY3LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAifQ.Gr3jeK7KRuNU9TvL12Bcb02hlN4BHjDyAORNsqr6ub0','2021-04-29 14:37:47','d561cf85-909f-4a95-b22c-b73b99e3eaaa','male');
INSERT INTO customers VALUES(9,'09123456','trong@gmail.com','0931421322','AQAAAAEAACcQAAAAEB5FfJylH2wjOjvh1Jp2xqrUpMm6Ix07UOdk6Tc0o70tPlfZW6v5FaJ7FDTtV53jSQ==','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOiIzYWI5ZmEyOC1iMTA0LTQ0OGMtYTdiMi1hYzU1YWQ4NmY4M2MiLCJzdWIiOiIwOTMxNDIxMzIyIiwianRpIjoiOGI1NWZmMzEtZWIyZS00NTMzLTgyMTYtNWEzZWM3ZjU5MzQ4Iiwicm9sZSI6ImN1c3RvbWVyIiwiZXhwIjoxNjE5NzA3MjM5LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAifQ.mkRUCQ6CCSXJe4hP7NwJUzVCkWjrJPtVilxTpwCmBqA','2021-04-29 14:40:39','5071ec09-f84a-4d67-a536-c88813be6fe1','male');
INSERT INTO customers VALUES(10,'09123456','trong@gmail.com','0931421322','AQAAAAEAACcQAAAAEB5FfJylH2wjOjvh1Jp2xqrUpMm6Ix07UOdk6Tc0o70tPlfZW6v5FaJ7FDTtV53jSQ==','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIwOTMxNDIxMzIyIiwianRpIjoiMTZiZWIzZGEtN2MxNi00NDdkLWI5MTAtNTA5OTQzZTQ3MzBiIiwicm9sZSI6ImN1c3RvbWVyIiwiZXhwIjoxNjE5NzExNTY5LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAifQ.mQ3_i9LC_tZ0SIuSCCp9Tunotj9WR8NcGeGc-za5ejQ','2021-04-29 15:52:49','fe4b78e3-06cb-4d28-b614-61ac9eb026f5','male');
INSERT INTO customers VALUES(11,'09123456','trong@gmail.com','0931421322','AQAAAAEAACcQAAAAEB5FfJylH2wjOjvh1Jp2xqrUpMm6Ix07UOdk6Tc0o70tPlfZW6v5FaJ7FDTtV53jSQ==','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIzYWI5ZmEyOC1iMTA0LTQ0OGMtYTdiMi1hYzU1YWQ4NmY4M2MiLCJqdGkiOiJkMzA0OGIxYy05MDFhLTRjZjItYTQ2NS00MGI4ZDRlNDVlNGQiLCJyb2xlIjoiY3VzdG9tZXIiLCJleHAiOjE2MTk3MTE3ODksImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAwMSIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NDIwMCJ9.y-abAFSJCcubckTH4ostSGnoDPqKG5JbbIRbv_g8oJ0','2021-04-29 15:56:29','6e6e2178-752e-4f62-ae59-cc2801f01de8','male');
INSERT INTO customers VALUES(12,'09123456','trong@gmail.com','0931421322','AQAAAAEAACcQAAAAEB5FfJylH2wjOjvh1Jp2xqrUpMm6Ix07UOdk6Tc0o70tPlfZW6v5FaJ7FDTtV53jSQ==','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIzYWI5ZmEyOC1iMTA0LTQ0OGMtYTdiMi1hYzU1YWQ4NmY4M2MiLCJqdGkiOiI1YWU1YjEwZi0yZDhjLTQ5NmYtYWY1Ny1iNjAwNDFlYWI1ZDYiLCJyb2xlIjoiY3VzdG9tZXIiLCJleHAiOjE2MTk3MTIwMTYsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAwMSIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NDIwMCJ9.wBrh_PGW0d7mDW6dGp0-O8a5xiKqsUDMxJuBmT9pbog','2021-04-29 16:00:16','66ec6d0d-d380-46f5-b74a-95e2149cedd3','male');
INSERT INTO customers VALUES(13,'09123456','trong@gmail.com','0931421322','AQAAAAEAACcQAAAAEB5FfJylH2wjOjvh1Jp2xqrUpMm6Ix07UOdk6Tc0o70tPlfZW6v5FaJ7FDTtV53jSQ==','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIzYWI5ZmEyOC1iMTA0LTQ0OGMtYTdiMi1hYzU1YWQ4NmY4M2MiLCJqdGkiOiJmMzdmYTU5Yi02NzNjLTQxMTgtYjA0Yy1mNGIwMWU4NzJlNzciLCJyb2xlIjoiY3VzdG9tZXIiLCJleHAiOjE2MTk3MTI2NzQsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAwMSIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NDIwMCJ9.cSOZHDWLZvLAG6mLo8GkKInN1CxcLoPrFqD4Gx5Q2Nk','2021-04-29 16:11:14','0ee9046c-9aa9-495a-9b3c-0228c8ac54d7','male');
INSERT INTO customers VALUES(14,'09123456','trong@gmail.com','0931421322','AQAAAAEAACcQAAAAEB5FfJylH2wjOjvh1Jp2xqrUpMm6Ix07UOdk6Tc0o70tPlfZW6v5FaJ7FDTtV53jSQ==','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIzYWI5ZmEyOC1iMTA0LTQ0OGMtYTdiMi1hYzU1YWQ4NmY4M2MiLCJqdGkiOiJmODExOGNmYy1hM2ZhLTQ5YjktOGNkMi00ZmY0N2ZkMTRmMDMiLCJyb2xlIjoiY3VzdG9tZXIiLCJleHAiOjE2MTk3MTU5NjUsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAwMSIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NDIwMCJ9.HeDkznh2qZWZh3x7g4t7GK98Rrnt4V03w8uCcxwy3zs','2021-04-29 17:06:05','9e3b667f-3b1e-4028-bfaa-8603ccaecb30','male');
INSERT INTO customers VALUES(15,'09123456','trong@gmail.com','0931421322','AQAAAAEAACcQAAAAEB5FfJylH2wjOjvh1Jp2xqrUpMm6Ix07UOdk6Tc0o70tPlfZW6v5FaJ7FDTtV53jSQ==','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIwOTMxNDIxMzIyIiwianRpIjoiOGE0NmE4ZjAtODQxNS00OWQyLWFhZjctYTkzZmUwMTc0ZjU1Iiwicm9sZSI6ImN1c3RvbWVyIiwiZXhwIjoxNjE5NzE2MDI1LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAifQ.7lM-e1YYFffdjNK0fja8BxNDsn1StcHi4Z8VLkHgbqw','2021-04-29 17:07:05','3768800f-cd5d-49a6-acac-9d296c157f28','male');
INSERT INTO customers VALUES(16,'09123456','trong@gmail.com','0931421322','AQAAAAEAACcQAAAAEB5FfJylH2wjOjvh1Jp2xqrUpMm6Ix07UOdk6Tc0o70tPlfZW6v5FaJ7FDTtV53jSQ==','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIwOTMxNDIxMzIyIiwianRpIjoiMmEzOGE4ZGYtNzk3OS00NDI2LWEyYTgtOTMxZWFjZjNlZmMxIiwicm9sZSI6ImN1c3RvbWVyIiwiZXhwIjoxNjE5NzE2MDc1LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAifQ.tKFVGDxXIuTlncer7eDJDKV4a4YDYe5D8OwnIM6Pi88','2021-04-29 17:07:55','54f8895b-8915-4106-9b46-3cc8f39c0b86','male');
INSERT INTO customers VALUES(17,'09123456','trong@gmail.com','0931421322','AQAAAAEAACcQAAAAEB5FfJylH2wjOjvh1Jp2xqrUpMm6Ix07UOdk6Tc0o70tPlfZW6v5FaJ7FDTtV53jSQ==','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIwOTMxNDIxMzIyIiwianRpIjoiNmViYmRlNjUtMWJjOS00MTM0LWE2MGYtNzM5YTViMmZjZWUyIiwicm9sZSI6ImN1c3RvbWVyIiwiZXhwIjoxNjE5NzE2MTg5LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAifQ.wPBarnn5cKr8Byw3H9HaHzk7rsxAMAwQOXNBznFi5NA','2021-04-29 17:09:49','6f370169-9a0f-40a8-8888-ad8cf7a26e07','male');
INSERT INTO customers VALUES(18,'09123456','trong@gmail.com','0931421322','AQAAAAEAACcQAAAAEB5FfJylH2wjOjvh1Jp2xqrUpMm6Ix07UOdk6Tc0o70tPlfZW6v5FaJ7FDTtV53jSQ==','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIwOTMxNDIxMzIyIiwianRpIjoiZjIxYzNjZWEtZTVkOC00MzU1LTkyZDQtNDI2NzRjMzNhMzFhIiwicm9sZSI6ImN1c3RvbWVyIiwiZXhwIjoxNjE5NzE2Mjc2LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAifQ.Va3qWdhj46ym5QB4r1coZ3-oWMH38YDA6OFRJTvg068','2021-04-29 17:11:16','a8b1a5d9-172a-4709-8754-cf163e7c78f2','male');
INSERT INTO customers VALUES(19,'09123456','trong@gmail.com','0931421322','AQAAAAEAACcQAAAAEB5FfJylH2wjOjvh1Jp2xqrUpMm6Ix07UOdk6Tc0o70tPlfZW6v5FaJ7FDTtV53jSQ==','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIwOTMxNDIxMzIyIiwianRpIjoiZDUyM2U1MmUtMTI3ZC00Y2MwLTkyZjUtMTYyYzY5YmFkNTAxIiwicm9sZSI6ImN1c3RvbWVyIiwiZXhwIjoxNjE5NzE4ODc2LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAifQ.n7zcSSWJhuGqE5YaEd-caW2aEU06iWkgJcJpdjdtg9c','2021-04-29 17:54:36','f990ba60-c02c-4089-b25b-42452ded332e','male');
INSERT INTO customers VALUES(20,'09123456','trong@gmail.com','0931421322','AQAAAAEAACcQAAAAEB5FfJylH2wjOjvh1Jp2xqrUpMm6Ix07UOdk6Tc0o70tPlfZW6v5FaJ7FDTtV53jSQ==','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIwOTMxNDIxMzIyIiwianRpIjoiOGQwMTc3MTEtZWE1My00NGRkLWE1NjItNDEwNmY5MjBhOWQwIiwicm9sZSI6ImN1c3RvbWVyIiwiZXhwIjoxNjE5NzE5NTYwLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAifQ.sDGhumSfQxB0yETMmnvBJluxfaC5BpN3Sm5thIwifkw','2021-04-29 18:06:00','126dd2e3-f81e-4842-b1a0-0f606ea8c507','male');
INSERT INTO customers VALUES(21,'09123456','trong@gmail.com','0931421322','AQAAAAEAACcQAAAAEB5FfJylH2wjOjvh1Jp2xqrUpMm6Ix07UOdk6Tc0o70tPlfZW6v5FaJ7FDTtV53jSQ==','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIwOTMxNDIxMzIyIiwianRpIjoiMWE4ZmRjNDktYThmOC00ZmU1LTg2NTEtMTdlOTMwZWNlMDdlIiwicm9sZSI6ImN1c3RvbWVyIiwiZXhwIjoxNjE5NzIwMDUzLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAifQ.w_bOpQWmVQuUaOSaphy3XViJOTP2-MJS33A1P7RJynU','2021-04-29 18:14:13','26904029-38af-4c7f-9e87-f7ca59043581','male');
INSERT INTO customers VALUES(22,'09123456','trong@gmail.com','0931421322','AQAAAAEAACcQAAAAEB5FfJylH2wjOjvh1Jp2xqrUpMm6Ix07UOdk6Tc0o70tPlfZW6v5FaJ7FDTtV53jSQ==','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIwOTMxNDIxMzIyIiwianRpIjoiNDZiZmU2ZmEtMjM1My00NGM2LWIxMmQtMDJhOTM4YzZjMDI0Iiwicm9sZSI6ImN1c3RvbWVyIiwiZXhwIjoxNjE5NzIwMTIyLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAifQ.j2zDPpwKEhnkqVxB4tDLP-nIja7q19BzZtJxLcT_nlA','2021-04-29 18:15:22','4889cd39-3caf-4a17-93d9-3276fee12ad8','male');
INSERT INTO customers VALUES(23,'09123456','trong@gmail.com','0931421322','AQAAAAEAACcQAAAAEB5FfJylH2wjOjvh1Jp2xqrUpMm6Ix07UOdk6Tc0o70tPlfZW6v5FaJ7FDTtV53jSQ==','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIwOTMxNDIxMzIyIiwianRpIjoiMmY3MjQzMzAtOGE2OS00MjRmLWI4YzAtYWRmNWRiZWM1NTFhIiwicm9sZSI6ImN1c3RvbWVyIiwiZXhwIjoxNjE5NzIwMjE5LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAifQ.fzjtjm-rFnlE0YKspFuHxnBS-r8jbDys_O9FBh1CKU4','2021-04-29 18:16:59','7fc10071-005c-4970-b66c-bb4dc3816741','male');
INSERT INTO customers VALUES(24,'09123456','trong@gmail.com','0931421322','AQAAAAEAACcQAAAAEB5FfJylH2wjOjvh1Jp2xqrUpMm6Ix07UOdk6Tc0o70tPlfZW6v5FaJ7FDTtV53jSQ==','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIwOTMxNDIxMzIyIiwianRpIjoiNzY3MjU1NjgtYWJhMS00YWFhLTkxNzMtNTJlMTJiMWFlZDA3Iiwicm9sZSI6ImN1c3RvbWVyIiwiZXhwIjoxNjE5NzIwMjg4LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAifQ.8hZZYhpKzRm73Vtn762xri_VxfvioT-PIywRkD3QhoE','2021-04-29 18:18:08','73ad440f-31db-4735-a461-18904fee7bd2','male');
CREATE TABLE IF NOT EXISTS "ordertable" (

    "id" INTEGER NOT NULL CONSTRAINT "PK_ordertable" PRIMARY KEY AUTOINCREMENT,

    "createDate" TEXT NOT NULL,

    "updateDate" TEXT NOT NULL,

    "paymentMethod" TEXT NULL,

    "shippingFee" TEXT NOT NULL,

    "shippingAddress" TEXT NULL,

    "totalPrice" TEXT NOT NULL,

    "status" TEXT NULL

	, "customerId" INTEGER REFERENCES "customers" ("id")
);
CREATE TABLE IF NOT EXISTS "refreshtokens" (

    "id" INTEGER NOT NULL CONSTRAINT "PK_refreshtokens" PRIMARY KEY AUTOINCREMENT,

    "userName" TEXT NULL,

    "refreshToken" TEXT NULL,

    "isrevoked" INTEGER NOT NULL

);
INSERT INTO refreshtokens VALUES(1,'0931421321','0a26de9e-87a0-4b97-b39c-4aef23b820c8',0);
INSERT INTO refreshtokens VALUES(2,'0931421321','bcbb0ca0-3d68-47ac-b6e1-92bdf638b768',0);
INSERT INTO refreshtokens VALUES(3,'0931421322','cebb2613-f833-40a6-b810-d084328066d5',0);
INSERT INTO refreshtokens VALUES(4,'0931421322','224fd4bc-bad3-4316-8818-be0f2cfcbb86',0);
INSERT INTO refreshtokens VALUES(5,'0931421322','c8123fcc-1473-4381-a010-4bb6f6c66f68',0);
INSERT INTO refreshtokens VALUES(6,'0931421322','69dbb7b3-6487-484e-996d-20404c5ad781',0);
INSERT INTO refreshtokens VALUES(7,'0931421322','0dae9265-4321-4386-bbcd-dc895686c14c',0);
INSERT INTO refreshtokens VALUES(8,'0931421322','d561cf85-909f-4a95-b22c-b73b99e3eaaa',0);
INSERT INTO refreshtokens VALUES(9,'0931421322','5071ec09-f84a-4d67-a536-c88813be6fe1',0);
INSERT INTO refreshtokens VALUES(10,'0931421322','fe4b78e3-06cb-4d28-b614-61ac9eb026f5',0);
INSERT INTO refreshtokens VALUES(11,'0931421322','6e6e2178-752e-4f62-ae59-cc2801f01de8',0);
INSERT INTO refreshtokens VALUES(12,'0931421322','66ec6d0d-d380-46f5-b74a-95e2149cedd3',0);
INSERT INTO refreshtokens VALUES(13,'0931421322','0ee9046c-9aa9-495a-9b3c-0228c8ac54d7',0);
INSERT INTO refreshtokens VALUES(14,'0931421322','9e3b667f-3b1e-4028-bfaa-8603ccaecb30',0);
INSERT INTO refreshtokens VALUES(15,'0931421322','3768800f-cd5d-49a6-acac-9d296c157f28',0);
INSERT INTO refreshtokens VALUES(16,'0931421322','54f8895b-8915-4106-9b46-3cc8f39c0b86',0);
INSERT INTO refreshtokens VALUES(17,'0931421322','6f370169-9a0f-40a8-8888-ad8cf7a26e07',0);
INSERT INTO refreshtokens VALUES(18,'0931421322','a8b1a5d9-172a-4709-8754-cf163e7c78f2',0);
INSERT INTO refreshtokens VALUES(19,'0931421322','f990ba60-c02c-4089-b25b-42452ded332e',0);
INSERT INTO refreshtokens VALUES(20,'0931421322','126dd2e3-f81e-4842-b1a0-0f606ea8c507',0);
INSERT INTO refreshtokens VALUES(21,'0931421322','26904029-38af-4c7f-9e87-f7ca59043581',0);
INSERT INTO refreshtokens VALUES(22,'0931421322','4889cd39-3caf-4a17-93d9-3276fee12ad8',0);
INSERT INTO refreshtokens VALUES(23,'0931421322','7fc10071-005c-4970-b66c-bb4dc3816741',0);
INSERT INTO refreshtokens VALUES(24,'0931421322','73ad440f-31db-4735-a461-18904fee7bd2',0);
INSERT INTO refreshtokens VALUES(25,'0931421322','9763cf53-7169-4e6b-a641-2b7e3c3a203f',0);
INSERT INTO refreshtokens VALUES(26,'0858267296','5d912915-19ba-468e-a0ed-fd0d62ac805a',0);
INSERT INTO refreshtokens VALUES(27,'0858267296','aec46201-eebb-483f-9e83-1b00acb1ab62',0);
INSERT INTO refreshtokens VALUES(28,'0858267296','f8d0f944-a2c7-4caf-ab50-24c82e0432da',0);
INSERT INTO refreshtokens VALUES(29,'0858267296','51779ed8-3f33-4091-b21b-fe1890cc1bf4',0);
INSERT INTO refreshtokens VALUES(30,'0858267296','ffdbf8c2-a104-46a5-a405-ab4b0a47980c',0);
CREATE TABLE IF NOT EXISTS "seller" (

    "id" INTEGER NOT NULL CONSTRAINT "PK_seller" PRIMARY KEY AUTOINCREMENT,

    "phoneNumer" TEXT NULL,

    "name" TEXT NOT NULL,

    "email" TEXT NOT NULL,

    "password" TEXT NOT NULL,

    "secretKey" TEXT NULL,

    "accessToken" TEXT NULL,

    "accessExpire" TEXT NOT NULL,

    "refreshToken" TEXT NULL

);
CREATE TABLE IF NOT EXISTS "AspNetRoleClaims" (

    "Id" INTEGER NOT NULL CONSTRAINT "PK_AspNetRoleClaims" PRIMARY KEY AUTOINCREMENT,

    "RoleId" TEXT NOT NULL,

    "ClaimType" TEXT NULL,

    "ClaimValue" TEXT NULL,

    CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE

);
CREATE TABLE IF NOT EXISTS "AspNetUserClaims" (

    "Id" INTEGER NOT NULL CONSTRAINT "PK_AspNetUserClaims" PRIMARY KEY AUTOINCREMENT,

    "UserId" TEXT NOT NULL,

    "ClaimType" TEXT NULL,

    "ClaimValue" TEXT NULL,

    CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE

);
CREATE TABLE IF NOT EXISTS "AspNetUserLogins" (

    "LoginProvider" TEXT NOT NULL,

    "ProviderKey" TEXT NOT NULL,

    "ProviderDisplayName" TEXT NULL,

    "UserId" TEXT NOT NULL,

    CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY ("LoginProvider", "ProviderKey"),

    CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE

);
CREATE TABLE IF NOT EXISTS "AspNetUserRoles" (

    "UserId" TEXT NOT NULL,

    "RoleId" TEXT NOT NULL,

    CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY ("UserId", "RoleId"),

    CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE,

    CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE

);
INSERT INTO AspNetUserRoles VALUES('df881f98-636e-4389-91a7-cd20d2e564d1','3c6ced2c-cab9-4d39-8e88-82784a334717');
INSERT INTO AspNetUserRoles VALUES('3ab9fa28-b104-448c-a7b2-ac55ad86f83c','3c6ced2c-cab9-4d39-8e88-82784a334717');
INSERT INTO AspNetUserRoles VALUES('a9ea49aa-444f-415e-a2c3-35a521a71f5f','24ba40a8-1b4a-48ad-8162-73c52bfadd1b');
CREATE TABLE IF NOT EXISTS "AspNetUserTokens" (

    "UserId" TEXT NOT NULL,

    "LoginProvider" TEXT NOT NULL,

    "Name" TEXT NOT NULL,

    "Value" TEXT NULL,

    CONSTRAINT "PK_AspNetUserTokens" PRIMARY KEY ("UserId", "LoginProvider", "Name"),

    CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE

);
CREATE TABLE IF NOT EXISTS "product" (

    "id" INTEGER NOT NULL CONSTRAINT "PK_product" PRIMARY KEY AUTOINCREMENT,

    "categoryId" INTEGER NOT NULL,

    "brandId" INTEGER NOT NULL,

    "productName" TEXT NULL,

    "description" TEXT NULL,

    "status" TEXT NULL,

    CONSTRAINT "FK_product_brands_brandId" FOREIGN KEY ("brandId") REFERENCES "brands" ("id") ON DELETE CASCADE,

    CONSTRAINT "FK_product_category_categoryId" FOREIGN KEY ("categoryId") REFERENCES "category" ("id") ON DELETE CASCADE

);
INSERT INTO product VALUES(1,1,1,'New phone','newest product','yes');
INSERT INTO product VALUES(2,1,2,'Vains','newest product1','active');
CREATE TABLE IF NOT EXISTS "addresses" (

    "id" INTEGER NOT NULL CONSTRAINT "PK_addresses" PRIMARY KEY AUTOINCREMENT,

    "cusId" INTEGER NOT NULL,

    "street" TEXT NULL,

    "address1" TEXT NULL,

    "address2" TEXT NULL,

    "address3" TEXT NULL,

 CONSTRAINT "FK_addresses_customers_cusId" FOREIGN KEY ("cusId") REFERENCES "customers" ("id") ON DELETE CASCADE

);
CREATE TABLE IF NOT EXISTS "cart" (

    "id" INTEGER NOT NULL CONSTRAINT "PK_cart" PRIMARY KEY AUTOINCREMENT,

    "customerId" INTEGER NOT NULL,

    "shippingFee" TEXT NOT NULL,

    "totalPrice" TEXT NOT NULL,

    "orderItem" TEXT NULL,

 FOREIGN KEY ("customerId") REFERENCES "customers" ("id") ON DELETE CASCADE

);
CREATE TABLE IF NOT EXISTS "selleraddresses" (

    "id" INTEGER NOT NULL CONSTRAINT "PK_selleraddresses" PRIMARY KEY AUTOINCREMENT,

    "sellerId" INTEGER NOT NULL,

    "street" TEXT NULL,

    "address1" TEXT NULL,

    "address2" TEXT NULL,

    "address3" TEXT NULL,

CONSTRAINT "FK_selleraddresses_seller_sellerId" FOREIGN KEY ("sellerId") REFERENCES "seller" ("id") ON DELETE CASCADE

);
CREATE TABLE IF NOT EXISTS "skus" (

    "id" INTEGER NOT NULL CONSTRAINT "PK_skus" PRIMARY KEY AUTOINCREMENT,

    "seller_sku" TEXT NULL,

    "productId" INTEGER NOT NULL,

    "available" INTEGER NOT NULL,

    "quantity" INTEGER NOT NULL,

    "color" TEXT NULL,

    "size" INTEGER NOT NULL,

    "height" INTEGER NOT NULL,

    "width" INTEGER NOT NULL,

    "length" INTEGER NOT NULL,

    "weight" INTEGER NOT NULL,

    "price" TEXT NOT NULL,

CONSTRAINT "FK_skus_product_productId" FOREIGN KEY ("productId") REFERENCES "product" ("id") ON DELETE CASCADE
);
INSERT INTO skus VALUES(0,'nuyen van B',1,1,100,'Xanh',15,20,300,200,30,'20.0');
INSERT INTO skus VALUES(1,'Nguyen van B',1,1,100,'Xanh',15,20,300,200,30,'20.0');
INSERT INTO skus VALUES(2,'Nguyen van A',2,1,100,'Đỏ',15,20,300,200,30,'35.0');
INSERT INTO skus VALUES(3,'n van B',1,1,100,'Xanh',15,20,300,200,30,'20.0');
CREATE TABLE IF NOT EXISTS "images" (

    "id" INTEGER NOT NULL CONSTRAINT "PK_images" PRIMARY KEY AUTOINCREMENT,

    "url" TEXT NULL,

    "skuId" INTEGER NOT NULL,

CONSTRAINT "FK_images_skus_skuId" FOREIGN KEY ("skuId") REFERENCES "skus" ("id") ON DELETE CASCADE

);
INSERT INTO images VALUES(2,'api/images/bitmap/vains.jpg',2);
INSERT INTO images VALUES(3,'api/images/bitmap/bitis.jpg',1);
INSERT INTO images VALUES(4,'api/images/bitmap/1868118363132634026669246213.jpg',3);
CREATE TABLE IF NOT EXISTS "orderitem" (

    "id" INTEGER NOT NULL CONSTRAINT "PK_orderitem" PRIMARY KEY AUTOINCREMENT,

    "orderTableId" INTEGER NOT NULL,

    "skuId" INTEGER NOT NULL,

    "name" TEXT NULL,

    "variation" TEXT NULL,

    "price" TEXT NOT NULL,

    "quantity" INTEGER NOT NULL,

    "tableid" INTEGER NULL,

CONSTRAINT "FK_orderitem_ordertable_tableid" FOREIGN KEY ("tableid") REFERENCES "ordertable" ("id") ON DELETE RESTRICT,

CONSTRAINT "FK_orderitem_skus_skuId" FOREIGN KEY ("skuId") REFERENCES "skus" ("id") ON DELETE CASCADE
);
DELETE FROM sqlite_sequence;
INSERT INTO sqlite_sequence VALUES('brands',3);
INSERT INTO sqlite_sequence VALUES('category',1);
INSERT INTO sqlite_sequence VALUES('product',2);
INSERT INTO sqlite_sequence VALUES('skus',3);
INSERT INTO sqlite_sequence VALUES('refreshtokens',30);
INSERT INTO sqlite_sequence VALUES('customers',24);
INSERT INTO sqlite_sequence VALUES('images',4);
CREATE INDEX "IX_AspNetRoleClaims_RoleId" ON "AspNetRoleClaims" ("RoleId");
CREATE UNIQUE INDEX "RoleNameIndex" ON "AspNetRoles" ("NormalizedName");
CREATE INDEX "IX_AspNetUserClaims_UserId" ON "AspNetUserClaims" ("UserId");
CREATE INDEX "IX_AspNetUserLogins_UserId" ON "AspNetUserLogins" ("UserId");
CREATE INDEX "IX_AspNetUserRoles_RoleId" ON "AspNetUserRoles" ("RoleId");
CREATE INDEX "EmailIndex" ON "AspNetUsers" ("NormalizedEmail");
CREATE UNIQUE INDEX "UserNameIndex" ON "AspNetUsers" ("NormalizedUserName");
CREATE INDEX "IX_cart_customerId" ON "cart" ("customerId");
COMMIT;