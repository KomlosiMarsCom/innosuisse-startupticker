﻿namespace Innosuisse.Startupticker.WebApp.Server.Utils
{
    public static class VectorUtils
    {
        public static double CosineSimilarity(float[] vectorA, float[] vectorB)
        {
            double dot = 0.0, normA = 0.0, normB = 0.0;

            for (int i = 0; i < vectorA.Length; i++)
            {
                dot += vectorA[i] * vectorB[i];
                normA += Math.Pow(vectorA[i], 2);
                normB += Math.Pow(vectorB[i], 2);
            }

            return dot / (Math.Sqrt(normA) * Math.Sqrt(normB));
        }
    }
}
