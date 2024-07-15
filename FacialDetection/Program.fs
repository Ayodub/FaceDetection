
open System
open Accord.Vision.Detection
open Accord.Vision.Detection.Cascades
open Accord.Imaging.Filters
open System.Drawing




[<EntryPoint>]
let main argv =
    let detector = new HaarObjectDetector (new FaceHaarCascade(),30)
    detector.SearchMode <- ObjectDetectorSearchMode.NoOverlap
    detector.ScalingMode <- ObjectDetectorScalingMode.SmallerToGreater
    detector.ScalingFactor <- 1.5f
    detector.UseParrallelProcessing <- true
    detector.Suppression <- 2

    let img = new Bitmap("some-guy.jpg")
    let objs = detector.ProcessFrame(img)


    if (objs.Length) > 0 then
        let marker = new RectanglesMarker(objs, Color.Fuschia);
        let newImg = marker.Apply(img)
        newImg.Save(@".\some-guy-with-box-around-face.jpg")
        printfn "Face detected from F#!"
        0

    else 
        printfn "Face Not Detected from F#!"
        0
  
     