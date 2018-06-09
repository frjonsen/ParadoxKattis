mod pathfinder;

use pathfinder::find_path;
use std::fs::File;
use std::io::prelude::*;
use std::fmt::Display;

fn read_map() -> (i32, i32, Vec<u8>) {
    let path = std::path::Path::new("sample.in");
    println!("{:?}", path);
    let mut file = File::open(path).expect("Error reading file");
    let mut contents= String::new();
    let mut start: i32 = -1;
    let mut end: i32 = -1;
    file.read_to_string(&mut contents).expect("Failed to read to string");

    let p_map: Vec<u8> = contents
        .chars()
        .filter(|c| "10SE".contains(*c))
        .enumerate()
        .map(|(i, c)| {
            if c == 'S' { start = (i as i32) }
            if c == 'E' { end = (i as i32) }
            match c {
                '0' => 0,
                _ => 1
            }
        } )
        .collect();

    if start == -1 || end == -1 { panic!("Unable to find start and end") }
    (start, end, p_map)
}

fn main() {
    read_map();
}
