GeneratedAudioLibrary
=====================

In order to test and audio app with a large library of assets it is necessary to generate
a large number of files with different track data from title, artist and album details
in a distributed way to see if any performance issues with a larger number of assets
does not cause any problems.

This .NET project uses the IdSharp library to insert tags into a sample mp3 file which
is then duplicated across a range of titles, artists and albums. It generates a fairly
large library. The size of the library can be controlled by the number of albums and
song assets are created in the nested for loop.

The generated library can then be imported into a device for performance testing. It
has been quite helpful in my work.

Audio Sample from Dr. Lex' Site
http://www.dr-lex.be/software/testsounds.html
