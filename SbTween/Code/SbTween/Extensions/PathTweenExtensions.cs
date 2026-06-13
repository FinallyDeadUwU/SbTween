using Sandbox;
using System;
using System.Collections.Generic;
namespace SbTween;

public static class PathTweenExtensions
{

    public static BaseTween TweenPath( this GameObject obj, IList<Vector3> points, float duration, bool lookAhead = false )
    {
       if ( points == null || points.Count < 2 ) return null;

       var tween = new BaseTween( duration );
       tween.Target = obj;

       int totalSegments = points.Count - 1;
       float[] segmentLengths = new float[totalSegments];
       float totalLength = 0f;

       for ( int i = 0; i < totalSegments; i++ )
       {
          segmentLengths[i] = Vector3.DistanceBetween( points[i], points[i + 1] );
          totalLength += segmentLengths[i];
       }

       return TweenManager.Instance.AddTween( tween
          .OnUpdate( p =>
          {
             if ( !obj.IsValid() ) return;
             if ( totalLength <= 0 ) return;

             float currentLengthPos = p * totalLength;
             float accumulatedLength = 0f;
             
             int targetSegment = 0;
             for ( int i = 0; i < totalSegments; i++ )
             {
                if ( currentLengthPos <= accumulatedLength + segmentLengths[i] )
                {
                   targetSegment = i;
                   break;
                }
                accumulatedLength += segmentLengths[i];
                targetSegment = i;
             }

             float segmentProgress = 0f;
             if ( segmentLengths[targetSegment] > 0 )
             {
                segmentProgress = (currentLengthPos - accumulatedLength) / segmentLengths[targetSegment];
             }

             Vector3 startPos = points[targetSegment];
             Vector3 endPos = points[targetSegment + 1];
             Vector3 nextPos = Vector3.Lerp( startPos, endPos, segmentProgress );

             if ( lookAhead && nextPos != obj.WorldPosition )
             {
                obj.WorldRotation = Rotation.LookAt( nextPos - obj.WorldPosition, Vector3.Up );
             }

             obj.WorldPosition = nextPos;
          } )
       );
    }

    public static BaseTween TweenPathCurve( this GameObject obj, IList<Vector3> points, float duration, bool lookAhead = false )
    {
       if ( points == null || points.Count < 2 ) return null;

       var tween = new BaseTween( duration );
       tween.Target = obj;

       return TweenManager.Instance.AddTween( tween
          .OnUpdate( p =>
          {
             if ( !obj.IsValid() ) return;

             Vector3 nextPos = GetCatmullRomPosition( points, p );

             if ( lookAhead && nextPos != obj.WorldPosition )
             {
                obj.WorldRotation = Rotation.LookAt( nextPos - obj.WorldPosition, Vector3.Up );
             }

             obj.WorldPosition = nextPos;
          } )
       );
    }

    private static Vector3 GetCatmullRomPosition( IList<Vector3> points, float pct )
    {
       int numSections = points.Count - 1;
       
       int currPt = (int)MathF.Floor( pct * numSections );
       currPt = Math.Clamp( currPt, 0, numSections - 1 );
       
       float t = (pct * numSections) - currPt;

       Vector3 p0 = points[Math.Clamp( currPt - 1, 0, points.Count - 1 )];
       Vector3 p1 = points[currPt];
       Vector3 p2 = points[Math.Clamp( currPt + 1, 0, points.Count - 1 )];
       Vector3 p3 = points[Math.Clamp( currPt + 2, 0, points.Count - 1 )];

       
       // https://en.wikipedia.org/wiki/Catmull–Rom_spline 
       return 0.5f * (
          (2f * p1) +
          (-p0 + p2) * t +
          (2f * p0 - 5f * p1 + 4f * p2 - p3) * t * t +
          (-p0 + 3f * p1 - 3f * p2 + p3) * t * t * t
       );
    }
}
