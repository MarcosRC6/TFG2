using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using UnityEditor;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using static UnityEditor.Progress;

public class BBDD
{
    public const uint ITEM_VACIO = 0;
    public const uint ITEM_PELUCA = 1;
    public const uint ITEM_CAPA = 2;
    public const uint ITEM_POCION_BUENA = 3;
    public const uint ITEM_POCION_MALA = 4;
    public const uint ITEM_HIERBA = 5;
    public const uint ITEM_GATOAYUDA = 6;
    public const uint ITEM_PERROAYUDA = 7;
    public const uint ITEM_CHANCLA = 8;
    private static IDbConnection dbconn;

    public static void Connect()
    {
        string conn = "URI=file:" + Application.dataPath + "/Database/zombs.db"; //Path to database.
        Debug.Log("Conexión " + conn);
        dbconn = (IDbConnection)new SqliteConnection(conn);
    }

    public static bool Create()
    {
        dbconn.Open();
        string queryNiveles = "CREATE TABLE IF NOT EXISTS niveles (id INT(2), idslot int(1), pasado int(1));";
        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = queryNiveles;
        dbcmd.ExecuteNonQuery();

        string queryPlayer = "CREATE TABLE IF NOT EXISTS personaje (idslot int(1), vidas INT(3), item int(1), monedas int (3));";
        dbcmd.CommandText = queryPlayer;
        dbcmd.ExecuteNonQuery();

        return true;
    }

    public static bool Comprobarslot(int idslot)
    {
        string query = "SELECT idslot from personaje where idslot="+idslot+";";
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = query;
        IDataReader reader = dbcmd.ExecuteReader();

        if (reader.Read())
        {
            reader.Close();
            return true;
        }
        else
        {
            reader.Close();
            return false;
        }
    }
    public static bool nuevaPartida(int idslot)
    {
        string queryNP = "insert into personaje values ("+idslot+", 5, "+ ITEM_VACIO+", 0);";
        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = queryNP;
        dbcmd.ExecuteNonQuery();

        for (int i = 0; i < 10; i++)
        {
            string queryNiveles = "insert into niveles values ("+i+", " + idslot + ", 0);";
            dbcmd.CommandText = queryNiveles;
            dbcmd.ExecuteNonQuery();
        }
            return true;
    }
}
