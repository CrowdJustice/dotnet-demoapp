#!/bin/sh

cd out
dotnet dotnet-demoapp.dll --urls http://*:$PORT
