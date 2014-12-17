namespace GeometryAPI
{
    using System;

    public class AdvancedFigureController : FigureController
    {
        public override void ExecuteFigureCreationCommand(string[] splitFigString)
        {
            switch (splitFigString[0])
            {
                case "circle":
                    {
                        Vector3D center = Vector3D.Parse(splitFigString[1]);
                        double radius = double.Parse(splitFigString[2]);
                        this.currentFigure = new Circle(center, radius);
                        break;
                    }
                case "cylinder":
                    {
                        Vector3D topCenter = Vector3D.Parse(splitFigString[1]);
                        Vector3D bottomCenter = Vector3D.Parse(splitFigString[2]);
                        double radius = double.Parse(splitFigString[3]);
                        this.currentFigure = new Cylinder(topCenter, bottomCenter, radius);
                        break;
                    }
                default:
                    base.ExecuteFigureCreationCommand(splitFigString);
                    break;
            }

            this.EndCommandExecuted = false;
        }

        protected override void ExecuteFigureInstanceCommand(string[] splitCommand)
        {
            switch (splitCommand[0])
            {
                case "area":
                    {
                        var currentAsAreaMeasurable = this.currentFigure as IAreaMeasurable;
                        if (currentAsAreaMeasurable != null)
                            Console.WriteLine("{0:0.00}", currentAsAreaMeasurable.GetArea());
                        else
                            Console.WriteLine("undefined");
                        break;
                    }
                case "volume":
                    {
                        var currentAsVolumeMeasurabel = this.currentFigure as IVolumeMeasurable;
                        if (currentAsVolumeMeasurabel != null)
                            Console.WriteLine("{0:0.00}", currentAsVolumeMeasurabel.GetVolume());
                        else
                            Console.WriteLine("undefined");
                        break;
                    }
                case "normal":
                    {
                        var currentAsFlat = this.currentFigure as IFlat;
                        if (currentAsFlat != null)
                            Console.WriteLine(currentAsFlat.GetNormal());
                        else
                            Console.WriteLine("undefined");
                        break;
                    }
                default:
                    base.ExecuteFigureInstanceCommand(splitCommand);
                    break;
            }
        }
    }
}
