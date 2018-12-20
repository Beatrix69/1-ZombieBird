
public class GameConfig {

    private static bool jugando = true;

    //ME DEVUELVE SI ESTOY JUGANDO O NO
    public static bool IsPlaying()
    {
        return jugando;
    }

    // ESTO ESTARIA BIEN PERO LO MEJOR ESTA ABAJO
   /*public static void SetJugando(bool _jugando)
    {
        jugando = _jugando;
    }*/

    public static void ArrancaJuego()
    {
        jugando = true;
    }

    // PARA PARAR EL JUEGO
    public static void ParaJuego()
    {
        jugando = false;
    }
}
