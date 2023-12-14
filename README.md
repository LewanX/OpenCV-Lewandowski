# Proyecto OpenCV

Este proyecto utiliza OpenCV para procesar un video, detectar rostros y guardar imágenes de las caras detectadas.

# Estructura


```CSS
├── haarcascades
│ └── haarcascade_frontalface_default.xml
├── videos
│ └── video.mp4
├── frames
│ └── output
└── OpenCV.sln
```
# Funcionamiento
El programa leera en primera instancia un archivo de video dentro de la carpeta videos, luego comenzara con la operación de detección de rostros, a medida que lo ejecuta crea carpetas para distintas personas, esta funcion recorre todos los frames de dicho video.
<ul>
   <li>
      Recibe un video de una persona.
   </li>
   <li>
     Convierte el video en frames.
   </li>
   <li>
      Detecta las caras en cada frame.
   </li>
   <li>
     Calcula las diferencias faciales para cada cara detectada.
   </li>
   <li>
      Genera una imagen con las diferencias faciales para cada persona.
   </li>
</ul>



## Requisitos

- [OpenCvSharp](https://github.com/shimat/opencvsharp): Asegúrate de tener instalada esta biblioteca. Puedes instalarla a través de NuGet.

## Cómo ejecutar el proyecto

1. **Clonar el repositorio:**
   ```bash
   git clone https://github.com/LewanX/OpenCV-Lewandowski.git

)
# PROCESO
![image](https://github.com/LewanX/OpenCV-Lewandowski/assets/85626827/3295ceb4-89fa-455e-aed7-49c644e33bdc)
# RESULTADO
![image](https://github.com/LewanX/OpenCV-Lewandowski/assets/85626827/95d8cc20-d27e-4c5e-b8c8-3a1d9a0790fc)
![image](https://github.com/LewanX/OpenCV-Lewandowski/assets/85626827/2e28e6a5-ffa9-419f-a8a0-fdb187bfdb03)
![image](https://github.com/LewanX/OpenCV-Lewandowski/assets/85626827/9b8005fc-d1d0-44ea-a640-2816f8660b63)





