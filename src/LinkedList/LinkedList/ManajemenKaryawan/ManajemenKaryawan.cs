using System;
using System.Collections.Generic;

namespace LinkedList.ManajemenKaryawan;

public class Karyawan
{
    public string NomorKaryawan { get; set; }
    public string Nama { get; set; }
    public string Posisi { get; set; }

    public Karyawan(string nomorKaryawan, string nama, string posisi)
    {
        NomorKaryawan = nomorKaryawan;
        Nama = nama;
        Posisi = posisi;
    }
}

public class KaryawanNode
{
    public Karyawan Karyawan { get; set; }
    public KaryawanNode Next { get; set; }
    public KaryawanNode Prev { get; set; }

    public KaryawanNode(Karyawan karyawan)
    {
        Karyawan = karyawan;
        Next = null;
        Prev = null;
    }
}

public class DaftarKaryawan
{
    private KaryawanNode head;
    private KaryawanNode tail;

    public DaftarKaryawan()
    {
        head = null;
        tail = null;
    }

    public void TambahKaryawan(Karyawan karyawan)
    {
        KaryawanNode newNode = new KaryawanNode(karyawan);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Prev = tail;
            tail = newNode;
        }
    }

    public bool HapusKaryawan(string nomorKaryawan)
    {
        if (head == null)
        {
            return false;
        }

        KaryawanNode current = head;

        while (current != null)
        {
            if (current.Karyawan.NomorKaryawan == nomorKaryawan)
            {
                if (current.Prev != null)
                {
                    current.Prev.Next = current.Next;
                }
                else
                {
                    head = current.Next;
                }

                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    tail = current.Prev;
                }

                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public Karyawan[] CariKaryawan(string kataKunci)
    {
        if (head == null)
        {
            return Array.Empty<Karyawan>();
        }

        List<Karyawan> hasilPencarian = new List<Karyawan>();
        KaryawanNode current = head;

        while (current != null)
        {
            if (current.Karyawan.Nama.Contains(kataKunci, StringComparison.OrdinalIgnoreCase) ||
                current.Karyawan.Posisi.Contains(kataKunci, StringComparison.OrdinalIgnoreCase))
            {
                hasilPencarian.Add(current.Karyawan);
            }

            current = current.Next;
        }

        return hasilPencarian.ToArray();
    }

    public string TampilkanDaftar()
    {
        if (tail == null)
        {
            return string.Empty;
        }

        var result = new System.Text.StringBuilder();
        KaryawanNode current = tail;
        while (current != null)
        {
            result.AppendLine($"{current.Karyawan.NomorKaryawan}; {current.Karyawan.Nama}; {current.Karyawan.Posisi}");
            current = current.Prev;
        }

        return result.ToString().TrimEnd();
    }
}