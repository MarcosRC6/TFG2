using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEditor;

using UnityEngine;


public class BBDD
{
    private static IDbConnection dbconn;
    private static int idPartida;
    public static int idNivel;
    private static int NUMERO_NIVELES = 3;

    
    public static void Connect()
    {
        string conn = "URI=file:" + Application.dataPath + "/StreamingAssets/zombs.db"; //Path to database.
        Debug.Log("Conexión " + conn);
        dbconn = (IDbConnection)new SqliteConnection(conn);
    }
    public static bool Create()
    {
        dbconn.Open();
        string queryNiveles = "CREATE TABLE IF NOT EXISTS niveles (idNivel INT(2), idPartida int(1), pasado int(1));";
        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = queryNiveles;
        dbcmd.ExecuteNonQuery();

        string queryPlayer = "CREATE TABLE IF NOT EXISTS partida (idPartida int(1), vidas INT(3), monedas int (3));";
        dbcmd.CommandText = queryPlayer;
        dbcmd.ExecuteNonQuery();
        dbconn.Close();
        return true;
    }

    public static bool Comprobarslot(int idPartida)
    {
        string query = "SELECT idPartida from partida where idPartida=" + idPartida + ";";
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = query;
        IDataReader reader = dbcmd.ExecuteReader();

        if (reader.Read())
        {

            reader.Close();
            dbconn.Close();
            return true;
        }
        else
        {
            reader.Close();
            dbconn.Close();
            return false;
        }
    }

    public static int[] ComprobarNivels()
    {
        string query = "SELECT idNivel, pasado from niveles where idPartida=" + idPartida + ";";
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = query;
        IDataReader reader = dbcmd.ExecuteReader();
        int[] niveles = new int[NUMERO_NIVELES];

        for (int i = 0; reader.Read(); i++)
        {
            niveles[reader.GetInt32(0)] = reader.GetInt32(1);


        }
        reader.Close();
        dbconn.Close();
        return niveles;
    }

    public static void seleccionarPartida(int idPartidaS)
    {
        idPartida = idPartidaS;
    }

    public static bool nuevaPartida()
    {
        dbconn.Open();
        string queryNP = "insert into partida values (" + idPartida + ", 5, 0);";
        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = queryNP;
        dbcmd.ExecuteNonQuery();

        for (int i = 0; i < NUMERO_NIVELES; i++)
        {
            String queryNiveles;
            if (i == 0)
                queryNiveles = "insert into niveles values (" + i + ", " + idPartida + ", 0);";
            else
                queryNiveles = "insert into niveles values (" + i + ", " + idPartida + ", 0);";
            dbcmd.CommandText = queryNiveles;
            dbcmd.ExecuteNonQuery();
        }
        dbconn.Close();
        return true;
    }

    public static int[] CargarPartida()
    {
        dbconn.Open();
        int[] partida = new int[2];
        string query = "SELECT vidas, monedas from partida where idPartida=" + idPartida + ";";
        //dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = query;
        IDataReader reader = dbcmd.ExecuteReader();

        if (reader.Read())
        {
            partida[0] = reader.GetInt32(0);
            partida[1] = reader.GetInt32(1);
            dbconn.Close();
            reader.Close();
        }
        else
        {
            dbconn.Close();
            reader.Close();

        }
        return partida;
    }

    public static bool nivelSuperado()
    {
        dbconn.Open();
        string queryNP = "update niveles set pasado = 1 where idNivel=" + idNivel + " and " + idPartida + ";";
        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = queryNP;
        dbcmd.ExecuteNonQuery();
        dbconn.Close();
        return true;
    }

    public static bool guaardarPartida(int vidas, int monedas)
    {
        dbconn.Open();
        string queryNP = "update partida set vidas = " + vidas + ", monedas =" + monedas + " where idPartida=" + idPartida + ";";
        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = queryNP;
        dbcmd.ExecuteNonQuery();
        dbconn.Close();
        return true;
    }

    public static bool borrarPartida()
    {
        dbconn.Open();
        string queryNP = "delete from partida where idPartida=" + idPartida + "; delete from niveles where idPartida=" + idPartida + ";";
        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = queryNP;
        dbcmd.ExecuteNonQuery();
        dbconn.Close();
        return true;
    }
}
