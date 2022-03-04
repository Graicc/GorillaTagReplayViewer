using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class ReplayFile
{
	const int FrameSize = 1 + 4 * 4;
	public List<ReplayFrame> frames = new List<ReplayFrame>();

	public static ReplayFile FromPath(string path)
	{
		ReplayFile replayFile = new ReplayFile();
		using (var reader = File.OpenRead(path))
		{
			byte[] frame = new byte[FrameSize];
			for (int i = 0; i < reader.Length; i+=FrameSize)
			{
				reader.Read(frame, 0, FrameSize);

				replayFile.frames.Add(new ReplayFrame(frame));
			}
		}
		return replayFile;
	}
}

public class ReplayFrame
{
	public enum DataCode : byte
	{
		Left,
		Right,
		Checkpoint,
		Teleport
	}

	public DataCode code;
	public float time;
	public Vector3 position;

	public ReplayFrame(byte[] buffer)
	{
		code = (DataCode)buffer[0];
		time = BitConverter.ToSingle(buffer, 1);
		position.x = BitConverter.ToSingle(buffer, 1 + 4);
		position.y = BitConverter.ToSingle(buffer, 1 + 4*2) + 5000;
		position.z = BitConverter.ToSingle(buffer, 1 + 4*3);
	}
}

public class ReplayLoader : MonoBehaviour
{
	public string fileName = "Assets/Recordings/GRAICgkz__beginnerblock115.3157-2021-19-7-22-28-42.gtrec";

	public GameObject leftHandPrefab;
	public GameObject rightHandPrefab;
	public LineRenderer lineRenderer;

	void Start()
	{
		//LoadReplay(fileName);
	}

	public void LoadReplay(string filePath)
	{
		var replay = ReplayFile.FromPath(filePath);
		lineRenderer.positionCount = replay.frames.Count;
		lineRenderer.SetPositions(replay.frames.Select(x => x.position).ToArray());
		foreach (ReplayFrame frame in replay.frames)
		{
			//Debug.Log($"{frame.code} | {frame.time} | {frame.position}");
			GameObject.Instantiate(frame.code == ReplayFrame.DataCode.Left ? leftHandPrefab : rightHandPrefab, frame.position, Quaternion.identity);
		}
	}

}
