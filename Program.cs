using System; 
class Program{
	static double calcularMedia(int[] roubos){
		double soma = 0; 
		double media = 0;
		for(int i = 0; i < roubos.Length; i++){
			soma+= roubos[i];
		}
		media = soma/roubos.Length;
		Console.WriteLine($"Media = {media} ");
		return(media);
	}
	top3BairrosViolentos(String[] bairros, int[] roubos){
		//terminar o codigo do vetor
	}
	static void Main(){
		String[] bairros = {"Centro", "Moema", "Pinheiros", "Itaquera", "Tatuapé",
"Santo Amaro", "Vila Mariana", "Lapa", "Capão Redondo", "Santana"}
		int[] roubos = {350, 120, 210, 480, 190, 310, 150, 280, 520, 240};
		calcularMedia(roubos);
	}
}