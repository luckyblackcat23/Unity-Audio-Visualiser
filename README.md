# Unity-Audio-Visualiser
audio visualiser for unity

make sure to make an audio source and place the audio visualization script on it.

set-up for ring

1: create an empty game object.

2: place the instantiate 512 cubes script onto it.

3: set the max scale to 100000(mess around with this value)

4: place a cube prefab into the prefab cube section.

set-up for cubes:

1: create 8 cubes.

2: place the param cube script on it.

3: set the start scale to 1 and the scale multiplier to 100.(mess around with the values if you want)

4: for each cube bring the band up by 1(starting at 0)for example... cube 1 = 0 cube 2 = 1... (change them in the inspector)

set-up for mic:

-1: set up the cubes or ring first.

0: set the use mic bool to true.

1: make an audio source.

2: make an audio mixer.

3: create a new group.

4: make the group you just created to -80 dB.

5: place the master group into the mixer group master slot.

6: place the group you created into the mixer group microphone group.

note: make sure the audio source is empty and doesnt have any sound playing.
