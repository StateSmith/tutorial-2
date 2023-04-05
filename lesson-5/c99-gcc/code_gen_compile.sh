#!/bin/bash
cd "$(dirname "$0")" # change to current script directory

# exit when any command fails
set -e

SRC=./src

# run user code generation script.
$SRC/LightSm.csx
# can also run c# script with this command instead: dotnet script $SRC/LightSm.csx

# compile code
echo Compiling with GCC
gcc -g -Wall -std=c99 -I $SRC $SRC/main.c $SRC/LightSm.c
